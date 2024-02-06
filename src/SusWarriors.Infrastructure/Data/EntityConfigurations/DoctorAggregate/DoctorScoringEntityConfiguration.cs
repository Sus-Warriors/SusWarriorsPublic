using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.DoctorAggregate;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.DoctorAggregate;
public class DoctorScoringEntityConfiguration : IEntityTypeConfiguration<DoctorScoring>
{
  public void Configure(EntityTypeBuilder<DoctorScoring> builder)
  {
    builder.HasKey(x => x.Id);
    builder.OwnsOne(x => x.Period);
  }
}
