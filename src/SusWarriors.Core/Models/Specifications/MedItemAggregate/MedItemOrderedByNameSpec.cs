using Ardalis.Specification;

namespace SusWarriors.Core.Models.Specifications.MedItemAggregate;
public class MedItemOrderedByNameSpec : MedItemSpec
{
  public MedItemOrderedByNameSpec(bool includeEmissions, bool medItemCategories, bool withTracking) 
    : base(includeEmissions, medItemCategories, withTracking)
  {
    Query.OrderBy(x => x.Name);
  }
}
