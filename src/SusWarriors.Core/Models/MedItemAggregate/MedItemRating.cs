namespace SusWarriors.Core.Models.MedItemAggregate;

/// <summary>
/// Score 1 -> 5
/// </summary>
public class MedItemRating : BaseEntity<Guid>
{
  public required Guid MedItemWithCategoryId { get; init; }
  // Rating 1 -> 5
  public required decimal Value { get; init; }
}
