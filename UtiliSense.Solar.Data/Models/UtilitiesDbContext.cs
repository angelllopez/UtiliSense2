using Microsoft.EntityFrameworkCore;

namespace UtiliSense.Solar.Data.Models;

public partial class UtilitiesDbContext : DbContext
{
    public UtilitiesDbContext()
    {
    }

    public UtilitiesDbContext(DbContextOptions<UtilitiesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SolarPowerActivity> SolarPowerActivities { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=UtilitiesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False\r\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SolarPowerActivity>(entity =>
        {
            entity.HasKey(e => e.SolarPowerActivityId).HasName("PK__SolarPow__31B96C99D6BCA594");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
