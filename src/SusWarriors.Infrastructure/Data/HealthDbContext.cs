using MediatR;
using Microsoft.EntityFrameworkCore;
using SusWarriors.Core.Models;
using SusWarriors.Infrastructure.Data.EntityConfigurations;
using SusWarriors.Infrastructure.Data.EntityConfigurations.DoctorAggregate;
using SusWarriors.Infrastructure.Data.EntityConfigurations.MedItemAggregate;
using SusWarriors.Infrastructure.Data.EntityConfigurations.PatientAggregate;

namespace SusWarriors.Infrastructure.Data;
public class HealthDbContext : DbContext
{
  private readonly IMediator _mediatr;

  public HealthDbContext(DbContextOptions<HealthDbContext> opts, IMediator mediatr) : base(opts)
  {
    _mediatr = mediatr;
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfiguration(new DoctorEntityConfiguration());
    modelBuilder.ApplyConfiguration(new DoctorScoringEntityConfiguration());
    modelBuilder.ApplyConfiguration(new PrescribedMedItemEntityConfiguration());
    modelBuilder.ApplyConfiguration(new MedItemEmissionsEntityConfiguration());
    modelBuilder.ApplyConfiguration(new MedItemEntityConfiguration());
    modelBuilder.ApplyConfiguration(new MedItemRatingEntityConfiguration());
    modelBuilder.ApplyConfiguration(new MedItemWithCategoryEntityConfiguration());
    modelBuilder.ApplyConfiguration(new PatientEntityConfiguration());
    modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
    modelBuilder.ApplyConfiguration(new MedItemCategoryEntityConfiguration());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_mediatr is null)
        return result;

    var entitiesWithEvents = ChangeTracker
      .Entries()
      .Select(e => e.Entity as BaseEntity<Guid>)
      .Where(e => e?.Events != null && e.Events.Any())
      .ToArray();

    foreach (var entity in entitiesWithEvents)
    {
        var events = entity!.Events.ToArray();
        entity.Events.Clear();
        foreach (var domainEvent in events)
        {
            await _mediatr.Publish(domainEvent).ConfigureAwait(false);
        }
    }

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }

}
