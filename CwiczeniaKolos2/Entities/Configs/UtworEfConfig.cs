using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2.Entities.Configs;

public class UtworEfConfig : IEntityTypeConfiguration<Utwor>
{
    public void Configure(EntityTypeBuilder<Utwor> builder)
    {
        builder
            .HasKey(u => u.IdUtwor)
            .HasName("Utwor_pk");

        builder
            .Property(u => u.IdUtwor)
            .ValueGeneratedOnAdd();

        builder
            .Property(u => u.NazwaUtworu)
            .IsRequired();

        builder
            .Property(u => u.CzasTrwania)
            .IsRequired();
        
        builder
            .HasOne(u => u.Album)
            .WithMany(u => u.Utwory)
            .IsRequired(false)
            .HasForeignKey(u => u.IdAlbum)
            .HasConstraintName("Utwor_Album")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .ToTable("Utwor");
    }
}