using SusWarriors.Application.Models.ViewModels.MedItems;
using SusWarriors.Application.Models.ViewModels.Patient;

namespace SusWarriors.Application.Models.ViewModels.Doctor;

public record DoctorPrescribedMedItemViewModel(Guid Id, PatientViewModel patient, 
  MedItemWithCategoryRatingViewModel Category, DateTimeOffset PrescribedDateTime,
  decimal Dosage);