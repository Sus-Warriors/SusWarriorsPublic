using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.MedItemAggregate;
public class MedItemRatingEntityConfiguration : IEntityTypeConfiguration<MedItemRating>
{
  public void Configure(EntityTypeBuilder<MedItemRating> builder)
  {
    builder.HasKey(x => x.Id);
  }
}
