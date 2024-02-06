using SusWarriors.Core.Interfaces;

namespace SusWarriors.Core.Models.MedItemAggregate;
public class MedItem : BaseEntity<Guid>, IAggregateRoot
{
  public required string Name { get; set; }
  public required decimal DosageWeight { get; set; }
  public MedItemEmissions? Emissions { get; set; }
  public IList<MedItemWithCategory> MedItemCategories { get; init; } = new List<MedItemWithCategory>();
}
