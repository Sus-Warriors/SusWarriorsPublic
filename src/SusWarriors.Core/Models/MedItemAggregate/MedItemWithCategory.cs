namespace SusWarriors.Core.Models.MedItemAggregate;
public class MedItemWithCategory : BaseEntity<Guid>
{
  public required Guid MedItemId { get; init; }
  public required Guid MedItemCategoryId { get; init; }
  public MedItemRating? Rating { get; set; }
  public MedItemCategory? MedItemCategory { get; init; }
}
