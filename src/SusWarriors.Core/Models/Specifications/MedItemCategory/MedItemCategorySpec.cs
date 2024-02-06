using Ardalis.Specification;

namespace SusWarriors.Core.Models.Specifications.MedItemCategory;
public class MedItemCategorySpec : Specification<Models.MedItemCategory>
{
  public MedItemCategorySpec(bool withRelationships, bool withRelationshipRatings, bool withTracking)
  {
    if (withTracking)
      Query.AsTracking();
    else
      Query.AsNoTracking();
    if (withRelationships)
    {
      if (withRelationshipRatings)
      {
        Query.Include(x => x.MedItemCategoryRelationships)
          .ThenInclude(x => x.Rating);
      }
      else
      {
        Query.Include(x => x.MedItemCategoryRelationships);
      }
    }
  }
}
