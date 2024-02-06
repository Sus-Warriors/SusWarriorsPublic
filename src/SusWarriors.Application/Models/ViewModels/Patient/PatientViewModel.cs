namespace SusWarriors.Application.Models.ViewModels.Patient;

public record PatientViewModel(Guid Id, string Name, int Age, string IdentifierNumber,
  string Gender, string BloodType);