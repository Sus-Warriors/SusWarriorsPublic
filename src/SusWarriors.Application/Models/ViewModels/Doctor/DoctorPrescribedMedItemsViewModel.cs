namespace SusWarriors.Application.Models.ViewModels.Doctor;

public record DoctorPrescribedMedItemsViewModel(
  ICollection<DoctorPrescribedMedItemViewModel> PrescribedItems);
