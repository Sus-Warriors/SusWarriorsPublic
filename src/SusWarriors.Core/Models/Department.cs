using SusWarriors.Core.Interfaces;

namespace SusWarriors.Core.Models;
public class Department : BaseEntity<Guid>, IAggregateRoot
{
  public required string Name { get; set; }
}
