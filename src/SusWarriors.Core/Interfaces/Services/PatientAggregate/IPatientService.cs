using SusWarriors.Core.Models.PatientAggregate;

namespace SusWarriors.Core.Interfaces.Services.PatientAggregate;
public interface IPatientService
{
  Task<Patient> GetPatientByIdentifierNumber(string identifierNumber);
}
