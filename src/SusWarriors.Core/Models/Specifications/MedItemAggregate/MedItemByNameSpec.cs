using Ardalis.Specification;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Core.Models.Specifications.MedItemAggregate;
public class MedItemByNameSpec : MedItemSpec, ISingleResultSpecification<MedItem>
{
  public MedItemByNameSpec(string name,
      bool includeEmissions, bool includeMedItemCategories, bool withTracking)
    : base(includeEmissions, includeMedItemCategories, withTracking)
  {
    Query.Where(x => x.Name == name);
  }
}
