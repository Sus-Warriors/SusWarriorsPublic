using Ardalis.Specification;

namespace SusWarriors.Core.Models.Specifications.MedItemAggregate;
public class MedItemsByIdsSpec : MedItemSpec
{
  public MedItemsByIdsSpec(ICollection<Guid> ids, bool includeEmissions, bool includeMedItemCategories, 
    bool withTracking)
    : base(includeEmissions, includeMedItemCategories, withTracking)
  {
    Query.Where(x => ids.Contains(x.Id));
  }
}
