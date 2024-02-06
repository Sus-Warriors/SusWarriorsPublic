using Ardalis.GuardClauses;
using SusWarriors.Application.Interfaces;
using SusWarriors.Application.Mappers;
using SusWarriors.Application.Models.ViewModels.Doctor;
using SusWarriors.Core.Interfaces.Data;
using SusWarriors.Core.Models.DoctorAggregate;
using SusWarriors.Core.Models.MedItemAggregate;
using SusWarriors.Core.Models.PatientAggregate;
using SusWarriors.Core.Models.Specifications.DoctorAggregate;
using SusWarriors.Core.Models.Specifications.MedItemAggregate;

namespace SusWarriors.Application.Services;

public class DoctorService : IDoctorService
{
  private readonly IRepository<Doctor> _doctorRepository;
  private readonly IReadRepository<Patient> _patientReadRepository;
  private readonly IReadRepository<MedItem> _medItemReadRepository;

  public DoctorService(IRepository<Doctor> doctorRepository, 
    IReadRepository<Patient> patientReadRepository, 
    IReadRepository<MedItem> medItemReadRepository)
  {
    _doctorRepository = doctorRepository;
    _patientReadRepository = patientReadRepository;
    _medItemReadRepository = medItemReadRepository;
  }

  public async Task<DoctorPrescribedMedItemViewModel> PrescribeMedItemForDoctor(Guid doctorId, 
    Guid patientId, Guid medItemId, Guid categoryId, decimal dosage)
  {
    Guard.Against.Default(doctorId, nameof(doctorId));
    var spec = new DoctorByIdSpec(doctorId, true, false, true);
    Doctor? doctor = await _doctorRepository.SingleOrDefaultAsync(spec);
    if (doctor is null)
      throw new NotFoundException(doctorId.ToString(), nameof(doctor));
    Patient? patient = await _patientReadRepository.GetByIdAsync(patientId);
    if (patient is null)
      throw new NotFoundException(patientId.ToString(), nameof(patient));
    var medItemSpec = new MedItemByIdSpec(medItemId, false, true, false);
    MedItem? medItem = await _medItemReadRepository.SingleOrDefaultAsync(medItemSpec);
    if (medItem is null)
      throw new NotFoundException(medItemId.ToString(), nameof(medItem));
    MedItemWithCategory? medItemWithCategory = medItem.MedItemCategories
      .SingleOrDefault(x => x.MedItemCategoryId == categoryId);
    if (medItemWithCategory is null)
      throw new NotFoundException(categoryId.ToString(), nameof(medItemWithCategory));
    var prescribedMedItem = doctor.PrescribeMedItem(medItemWithCategory.Id, patientId, dosage);
    await _doctorRepository.UpdateAsync(doctor);
    await _doctorRepository.SaveChangesAsync();
    var viewModel = DoctorMapper.MapPrescribedItemToViewModel(patient, medItem,
      medItemWithCategory, prescribedMedItem);
    return viewModel;
  }

  public async Task<DoctorPrescribedMedItemsViewModel> GetPrescribedMedItemsForDoctor(
    Guid doctorId)
  {
    Guard.Against.Default(doctorId, nameof(doctorId));
    var spec = new DoctorByIdSpec(doctorId, true, false, true);
    Doctor? doctor = await _doctorRepository.SingleOrDefaultAsync(spec);
    if (doctor is null)
      throw new NotFoundException(doctorId.ToString(), nameof(doctor));
    IList<Patient> patients = await _patientReadRepository.ListAsync();
    var medItemSpec = new MedItemSpec(false, true, false);
    IList<MedItem> medItems = await _medItemReadRepository.ListAsync(medItemSpec);
    IList<PrescribedMedItem> prescribedMedItems = doctor.PrescribedMedItems
      .OrderByDescending(x => x.DateTimeCreated)
      .ToList();
    IList<MedItemWithCategory> medItemWithCategories = medItems
      .SelectMany(x => x.MedItemCategories)
      .ToList();
    return DoctorMapper.MapPrescribedItemsToViewModel(patients, medItems,
      medItemWithCategories, prescribedMedItems);
  }
}
