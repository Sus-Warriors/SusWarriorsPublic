using Ardalis.Specification;
using SusWarriors.Core.Models.PatientAggregate;

namespace SusWarriors.Core.Models.Specifications.PatientAggregate;
public sealed class PatientByIdentifierNumberSpec : PatientSpec, ISingleResultSpecification<Patient>
{
  public PatientByIdentifierNumberSpec(string identifierNumber, bool withTracking) : base(withTracking)
  {
    Query.Where(x => x.IdentifierNumber == identifierNumber);
  }
}
