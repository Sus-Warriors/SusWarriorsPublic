using Ardalis.Specification.EntityFrameworkCore;
using SusWarriors.Core.Interfaces;
using System;
using SusWarriors.Core.Interfaces.Data;

namespace SusWarriors.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(HealthDbContext dbContext) : base(dbContext)
  {
  }
}
