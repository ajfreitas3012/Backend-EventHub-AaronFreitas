using Microsoft.EntityFrameworkCore;
using UsersService.Domain;
using EventsService.Domain;
using PaymentsService.Domain;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Event>().HasKey(e => e.Id);
        modelBuilder.Entity<Payment>().HasKey(p => p.Id);

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value)
                     .HasColumnName("Email")
                     .IsRequired();
            });
    }
}
