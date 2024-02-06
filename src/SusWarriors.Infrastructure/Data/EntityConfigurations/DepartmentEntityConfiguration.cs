using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SusWarriors.Core.Models;
using SusWarriors.Infrastructure.Data.Config;

namespace SusWarriors.Infrastructure.Data.EntityConfigurations;
public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
  public void Configure(EntityTypeBuilder<Department> builder)
  {
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Name)
      .HasMaxLength(ColumnConstants.DefaultNameLength);
  }
}
