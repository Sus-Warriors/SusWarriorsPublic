using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.MedItemAggregate;
public class MedItemEntityConfiguration : IEntityTypeConfiguration<MedItem>
{
  public void Configure(EntityTypeBuilder<MedItem> builder)
  {
    builder.HasKey(x => x.Id);
  }
}
