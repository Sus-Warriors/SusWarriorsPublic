using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusWarriors.Core.Events;
public abstract class BaseDomainEvent : INotification
{
  public Guid Id { get; init; } = Guid.NewGuid();
  public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
}