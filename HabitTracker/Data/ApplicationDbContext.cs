using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Habit> Habits => Set<Habit>();
    public DbSet<HabitEntry> HabitEntries => Set<HabitEntry>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Habit>()
            .HasOne(h => h.User)
            .WithMany()
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<HabitEntry>()
            .HasOne(e => e.Habit)
            .WithMany(h => h.Entries)
            .HasForeignKey(e => e.HabitId)
            .OnDelete(DeleteBehavior.Cascade);

        // A habit can only have one check-in entry per calendar date.
        builder.Entity<HabitEntry>()
            .HasIndex(e => new { e.HabitId, e.Date })
            .IsUnique();
    }
}
