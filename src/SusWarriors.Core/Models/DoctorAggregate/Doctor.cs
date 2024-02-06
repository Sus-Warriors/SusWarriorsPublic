using SusWarriors.Core.Constants;
using SusWarriors.Core.Interfaces;

namespace SusWarriors.Core.Models.DoctorAggregate;
public class Doctor : BaseEntity<Guid>, IAggregateRoot
{
  public required string Name { get; set; }
  public required Guid DepartmentId { get; set; }
  public IList<PrescribedMedItem> PrescribedMedItems { get; init; } = new List<PrescribedMedItem>();
  public IList<DoctorScoring> DoctorScorings { get; init; } = new List<DoctorScoring>();

  public PrescribedMedItem PrescribeMedItem(Guid medItemWithCategoryId, Guid patientId, decimal dosage)
  {
    var prescribedMedItem = new PrescribedMedItem
    {
      DoctorId = Id,
      PatientId = patientId,
      MedItemWithCategoryId = medItemWithCategoryId,
      PrescribedDateTime = DateTimeOffset.Now.ToOffset(GeneralConstants.SgtTimeSpan),
      Dosage = dosage,
    };
    PrescribedMedItems.Add(prescribedMedItem);
    return prescribedMedItem;
  }
}
