using Ardalis.Specification;
using SusWarriors.Core.Interfaces;

namespace SusWarriors.Core.Interfaces.Data;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}