using SusWarriors.Application.Models.ViewModels.Patient;
using SusWarriors.Core.Models.PatientAggregate;

namespace SusWarriors.Application.Mappers;

public class PatientMapper
{
  public static PatientViewModel MapPatientToViewModel(Patient patient)
  {
    return new PatientViewModel(
      Id: patient.Id,
      Name: patient.Name,
      Age: patient.Age,
      IdentifierNumber: patient.IdentifierNumber,
      Gender: patient.Gender.ToString(),
      BloodType: patient.BloodType);
  }
}
