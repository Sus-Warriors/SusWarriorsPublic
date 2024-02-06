using Ardalis.Specification;
using SusWarriors.Core.Models.PatientAggregate;

namespace SusWarriors.Core.Models.Specifications.PatientAggregate;
public class PatientSpec : Specification<Patient>
{
    public PatientSpec(bool withTracking)
    {
        if (!withTracking)
            Query.AsNoTracking();
    }
}
