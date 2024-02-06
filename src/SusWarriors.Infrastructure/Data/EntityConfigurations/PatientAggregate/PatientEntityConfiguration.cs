using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models.PatientAggregate;
using SusWarriors.Infrastructure.Data.Config;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations.PatientAggregate;
public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
{
  public void Configure(EntityTypeBuilder<Patient> builder)
  {
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Name)
      .HasMaxLength(ColumnConstants.DefaultNameLength);
    builder.Property(x => x.IdentifierNumber)
      .HasMaxLength(ColumnConstants.DefaultNameLength);
    builder.Property(x => x.BloodType)
      .HasMaxLength(ColumnConstants.DefaultNameLength);
  }
}
