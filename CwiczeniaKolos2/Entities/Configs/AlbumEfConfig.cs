using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2.Entities.Configs;

public class AlbumEfConfig : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder
            .HasKey(a => a.IdAlbum)
            .HasName("Album_pk");

        builder
            .Property(a => a.IdAlbum)
            .ValueGeneratedOnAdd();
        
        builder
            .Property(a => a.NazwaAlbumu)
            .IsRequired();

        builder
            .Property(a => a.DataWydania)
            .IsRequired();

        builder
            .Property(a => a.IdWytwornia)
            .IsRequired();

        builder
            .HasOne(a => a.Wytwornia)
            .WithMany(a => a.Albumy)
            .HasForeignKey(a => a.IdWytwornia)
            .HasConstraintName("Album_Wytwornia")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .ToTable("Album");
    }
}