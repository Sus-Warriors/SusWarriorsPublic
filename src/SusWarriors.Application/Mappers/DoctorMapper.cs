using SusWarriors.Application.Models.ViewModels.Doctor;
using SusWarriors.Core.Models;
using SusWarriors.Core.Models.DoctorAggregate;
using SusWarriors.Core.Models.MedItemAggregate;
using SusWarriors.Core.Models.PatientAggregate;

namespace SusWarriors.Application.Mappers;

public static class DoctorMapper
{
  public static DoctorPrescribedMedItemViewModel MapPrescribedItemToViewModel(Patient patient,
    MedItem medItem, MedItemWithCategory medItemWithCategory, PrescribedMedItem prescribedMedItem)
  {
    return new DoctorPrescribedMedItemViewModel(prescribedMedItem.Id,
      PatientMapper.MapPatientToViewModel(patient),
      MedItemMapper.MapMedItemWithCategoryToViewModel(medItem, medItemWithCategory),
      prescribedMedItem.PrescribedDateTime, prescribedMedItem.Dosage);
  }

  public static DoctorPrescribedMedItemsViewModel MapPrescribedItemsToViewModel(
    IEnumerable<Patient> patients, IEnumerable<MedItem> medItems,
    IEnumerable<MedItemWithCategory> medItemsWithCategories,
    IEnumerable<PrescribedMedItem> prescribedMedItems)
  {
    return new DoctorPrescribedMedItemsViewModel(prescribedMedItems
      .Select(x =>
      {
        Patient patient = patients.Single(y => y.Id == x.PatientId);
        MedItemWithCategory medItemWithCategory = medItemsWithCategories
          .Single(y => y.Id == x.MedItemWithCategoryId);
        MedItem medItem = medItems.Single(y => y.Id == medItemWithCategory.MedItemId);
        return MapPrescribedItemToViewModel(patient, medItem, medItemWithCategory, x);
      }).ToList());
  }
}
