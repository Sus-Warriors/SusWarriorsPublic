using SusWarriors.Core.Enums;
using SusWarriors.Core.Interfaces;

namespace SusWarriors.Core.Models.PatientAggregate;
public class Patient : BaseEntity<Guid>, IAggregateRoot
{
  public required string Name { get; set; }
  public required int Age { get; set; }
  public required string IdentifierNumber { get; set; }
  public required Gender Gender { get; set; }
  public required string BloodType { get; set; }
}
