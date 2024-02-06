using Ardalis.Specification;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Core.Models.Specifications.MedItemAggregate;
public class MedItemByIdSpec : MedItemSpec, ISingleResultSpecification<MedItem>
{
  public MedItemByIdSpec(Guid id, bool includeEmissions, bool includeMedItemCategories, bool withTracking) 
    : base(includeEmissions, includeMedItemCategories, withTracking)
  {
    Query.Where(x => x.Id == id);
  }
}
