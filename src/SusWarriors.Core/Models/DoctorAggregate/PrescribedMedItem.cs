namespace SusWarriors.Core.Models.DoctorAggregate;
public class PrescribedMedItem : BaseEntity<Guid>
{
  public required Guid MedItemWithCategoryId { get; init; }
  public required Guid DoctorId { get; init; }
  public required Guid PatientId { get; init; }
  public required DateTimeOffset PrescribedDateTime { get; init; }
  public required decimal Dosage { get; init; }
}
