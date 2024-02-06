using Ardalis.GuardClauses;

namespace SusWarriors.Core.ValueObjects;

public class DateTimeOffsetRange : ValueObject
{
  public DateTimeOffset Start { get; private set; }

  public DateTimeOffset End { get; private set; }

  public DateTimeOffsetRange(DateTimeOffset start, DateTimeOffset end)
  {
    Guard.Against.OutOfRange(start, nameof(start), start, end);
    this.Start = start;
    this.End = end;
  }

  public DateTimeOffsetRange(DateTimeOffset start, TimeSpan duration)
    : this(start, start.Add(duration))
  {
  }

  public int DurationInMinutes() => (int)Math.Round((this.End - this.Start).TotalMinutes, 0);

  public
#nullable disable
    DateTimeOffsetRange NewDuration(TimeSpan newDuration) => new DateTimeOffsetRange(this.Start, newDuration);

  public DateTimeOffsetRange NewEnd(DateTimeOffset newEnd) => new DateTimeOffsetRange(this.Start, newEnd);

  public DateTimeOffsetRange NewStart(DateTimeOffset newStart) => new DateTimeOffsetRange(newStart, this.End);

  public static DateTimeOffsetRange CreateOneDayRange(DateTimeOffset day) => new DateTimeOffsetRange(day, day.AddDays(1.0));

  public static DateTimeOffsetRange CreateOneWeekRange(DateTimeOffset startDay) => new DateTimeOffsetRange(startDay, startDay.AddDays(7.0));

  public bool Overlaps(DateTimeOffsetRange dateTimeRange) => this.Start < dateTimeRange.End && this.End > dateTimeRange.Start;

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return (object)this.Start;
    yield return (object)this.End;
  }
}
