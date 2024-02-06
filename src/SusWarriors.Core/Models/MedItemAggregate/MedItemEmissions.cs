namespace SusWarriors.Core.Models.MedItemAggregate;
public class MedItemEmissions : BaseEntity<Guid>
{
  public required Guid MedItemId { get; init; }
  public required decimal EmissionValue { get; set; }
}
