using SusWarriors.Core.Constants;
using SusWarriors.Core.Events;

namespace SusWarriors.Core.Models;
public abstract class BaseEntity<TId>
{
  public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

  public TId Id { get; set; }
  public DateTimeOffset DateTimeCreated { get; init; } = DateTimeOffset.UtcNow.ToOffset(GeneralConstants.SgtTimeSpan);
  public DateTimeOffset DateTimeUpdated { get; set; } = DateTimeOffset.UtcNow.ToOffset(GeneralConstants.SgtTimeSpan);
}