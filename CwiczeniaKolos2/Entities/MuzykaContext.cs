using Kolos2.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Entities;

public class MuzykaContext : DbContext
{
    public virtual DbSet<Muzyk> Muzycy { get; set; }

    public virtual DbSet<WykonawcaUtworu> WykonawcyUtworow { get; set; }

    public virtual DbSet<Utwor> Utwory { get; set; }

    public virtual DbSet<Album> Albumy { get; set; }

    public virtual DbSet<Wytwornia> Wytwornie { get; set; }

    public MuzykaContext()
    {
    }

    public MuzykaContext(DbContextOptions<MuzykaContext> options) : base(options)
    {
    }

    // WAŻNE !!
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=master;User Id=sa;Password=bazaTestowa1234;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Aplikuje wszystkie konfigurację z folderu, ale podajemy jedną klasę tylko
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuzykEfConfig).Assembly);
    }
}