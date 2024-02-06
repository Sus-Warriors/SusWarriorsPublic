using Ardalis.Specification;
using SusWarriors.Core.Models.DoctorAggregate;

namespace SusWarriors.Core.Models.Specifications.DoctorAggregate;
public class DoctorByIdSpec : DoctorSpec, ISingleResultSpecification<Doctor>
{
  public DoctorByIdSpec(Guid id, bool includePrescribedMedItems, bool includeDoctorScorings,
    bool withTracking)
    : base(includePrescribedMedItems, includeDoctorScorings, withTracking)
  {
    Query.Where(x => x.Id == id);
  }
}
