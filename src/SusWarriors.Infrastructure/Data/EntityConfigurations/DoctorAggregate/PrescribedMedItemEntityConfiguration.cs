using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.DoctorAggregate;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.DoctorAggregate;
public class PrescribedMedItemEntityConfiguration : IEntityTypeConfiguration<PrescribedMedItem>
{
  public void Configure(EntityTypeBuilder<PrescribedMedItem> builder)
  {
    builder.HasKey(x => x.Id);
  }
}
