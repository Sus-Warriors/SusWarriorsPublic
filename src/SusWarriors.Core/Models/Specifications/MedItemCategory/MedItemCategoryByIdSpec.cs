using Ardalis.Specification;

namespace SusWarriors.Core.Models.Specifications.MedItemCategory;
public class MedItemCategoryByIdSpec : MedItemCategorySpec, ISingleResultSpecification<Models.MedItemCategory>
{
  public MedItemCategoryByIdSpec(Guid id, bool withRelationships, bool withRelationshipRatings, 
    bool withTracking) 
    : base(withRelationships, withRelationshipRatings, withTracking)
  {
    Query.Where(x => x.Id == id);
  }
}
