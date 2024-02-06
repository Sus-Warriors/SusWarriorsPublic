using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.DoctorAggregate;
using SusWarriors.Infrastructure.Data.Config;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.DoctorAggregate;
public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
{
  public void Configure(EntityTypeBuilder<Doctor> builder)
  {
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Name)
      .HasMaxLength(ColumnConstants.DefaultNameLength);
  }
}
