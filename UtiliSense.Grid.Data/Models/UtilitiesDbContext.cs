using Microsoft.EntityFrameworkCore;

namespace UtiliSense.Grid.Data.Models;

public partial class UtilitiesDbContext : DbContext
{
    public UtilitiesDbContext()
    {
    }

    public UtilitiesDbContext(DbContextOptions<UtilitiesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GridPowerConsumption> GridPowerConsumptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Localhost;Database=UtilitiesDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GridPowerConsumption>(entity =>
        {
            entity.HasKey(e => e.GridPowerConsumptionId).HasName("PK__GridPowe__4E80868CA19C0931");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
