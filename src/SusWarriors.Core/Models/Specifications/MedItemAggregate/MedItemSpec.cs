using Ardalis.Specification;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Core.Models.Specifications.MedItemAggregate;
public class MedItemSpec : Specification<MedItem>
{
  public MedItemSpec(bool includeEmissions, bool includeMedItemCategories, bool withTracking)
  {
    if (!withTracking)
      Query.AsNoTracking();
    else
      Query.AsTracking();
    if (includeEmissions)
      Query.Include(x => x.Emissions);
    if (includeMedItemCategories)
    {
      Query.Include(x => x.MedItemCategories)
        .ThenInclude(x => x.Rating);
      Query.Include(x => x.MedItemCategories)
        .ThenInclude(x => x.MedItemCategory);
    }
  }
}
