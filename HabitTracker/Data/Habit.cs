using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Data;

public class Habit
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public HabitFrequency Frequency { get; set; } = HabitFrequency.Daily;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Owner of this habit — ties back to ASP.NET Core Identity's user id.
    [Required]
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser? User { get; set; }

    public List<HabitEntry> Entries { get; set; } = new();
}

public enum HabitFrequency
{
    Daily,
    Weekly
}
