namespace DpWorld.Visitor.Domain.Entities;

public class Visitor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public string EntranceId { get; set; } = string.Empty;
    public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
}
