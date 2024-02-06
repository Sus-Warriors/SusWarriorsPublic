using SusWarriors.Core.ValueObjects;

namespace SusWarriors.Core.Models.DoctorAggregate;

/// <summary>
/// For Leaderboard
/// </summary>
public class DoctorScoring : BaseEntity<Guid>
{
  public required Guid DoctorId { get; init; }
  public required decimal Score { get; set; }
  public required int MedItemCount { get; set; } 
  public required DateTimeOffsetRange Period { get; init; }
  public required Guid DepartmentId { get; init; }
}
