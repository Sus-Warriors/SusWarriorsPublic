using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.MedItemAggregate;
public class MedItemEmissionsEntityConfiguration : IEntityTypeConfiguration<MedItemEmissions>
{
  public void Configure(EntityTypeBuilder<MedItemEmissions> builder)
  {
    builder.HasKey(x => x.Id);
  }
}
