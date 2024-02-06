using Ardalis.Specification;
using SusWarriors.Core.Interfaces;

namespace SusWarriors.Core.Interfaces.Data;

public interface IRepository<T> : IRepositoryBase<
#nullable disable
  T>, IReadRepositoryBase<
#nullable enable
  T> where T :
#nullable disable
  class, IAggregateRoot
{
}