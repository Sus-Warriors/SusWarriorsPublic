using SusWarriors.Application.Models.ViewModels.Doctor;
using SusWarriors.Core.Models.DoctorAggregate;

namespace SusWarriors.Application.Interfaces;

public interface IDoctorService
{
  Task<DoctorPrescribedMedItemViewModel> PrescribeMedItemForDoctor(Guid doctorId,
    Guid patientId, Guid medItemId, Guid categoryId, decimal dosage);
  Task<DoctorPrescribedMedItemsViewModel> GetPrescribedMedItemsForDoctor(
    Guid doctorId);
}
