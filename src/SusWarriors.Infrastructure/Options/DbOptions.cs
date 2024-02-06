namespace SusWarriors.Infrastructure.Options;
public sealed class DbOptions
{
  public string Server { get; set; } = "localhost";
  public short Port { get; set; } = 1433;
  public string User { get; set; } = "SA";
  public string Password { get; set; } = @"P@ssword123";
  public string Database { get; set; } = @"Identity";
}