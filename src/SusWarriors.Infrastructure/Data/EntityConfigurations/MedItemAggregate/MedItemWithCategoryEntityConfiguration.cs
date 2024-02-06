using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.MedItemAggregate;
public class MedItemWithCategoryEntityConfiguration : IEntityTypeConfiguration<MedItemWithCategory>
{
  public void Configure(EntityTypeBuilder<MedItemWithCategory> builder)
  {
    builder.HasKey(x => x.Id);
  }
}
