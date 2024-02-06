using SusWarriors.Core.Interfaces;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Core.Models;
public class MedItemCategory : BaseEntity<Guid>, IAggregateRoot
{
    public required string Name { get; set; }
    public IList<MedItemWithCategory> MedItemCategoryRelationships { get; init; } = new List<MedItemWithCategory>();
}
