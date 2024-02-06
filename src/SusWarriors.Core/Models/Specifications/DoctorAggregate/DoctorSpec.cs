using Ardalis.Specification;
using SusWarriors.Core.Models.DoctorAggregate;

namespace SusWarriors.Core.Models.Specifications.DoctorAggregate;
public class DoctorSpec : Specification<Doctor>
{
  public DoctorSpec(bool includePrescribedMedItems, bool includeDoctorScorings, bool withTracking)
  {
    if (withTracking)
      Query.AsTracking();
    else
      Query.AsNoTracking();
    if (includePrescribedMedItems)
      Query.Include(x => x.PrescribedMedItems);
    if (includeDoctorScorings)
      Query.Include(x => x.DoctorScorings);
  }
}
