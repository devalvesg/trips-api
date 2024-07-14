using Journey.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journey.Infrastructure.Entities;
[Table("Activities")]
public class Activity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public ActivityStatus Status { get; set; } = ActivityStatus.Pending;
    public Guid TripId { get; set; }
}
