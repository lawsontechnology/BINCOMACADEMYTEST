using Microsoft.EntityFrameworkCore;

namespace BINCOMACADEMYTEST;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Inquiry> Inquiries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Inquiry>()
        .HasKey(a => a.Id);

        modelBuilder.Entity<Car>()
        .Property(c => c.Price)
        .HasPrecision(18, 2);
    }
  }
