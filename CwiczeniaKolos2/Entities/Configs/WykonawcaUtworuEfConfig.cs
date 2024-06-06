using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2.Entities.Configs;

public class WykonawcaUtworuEfConfig : IEntityTypeConfiguration<WykonawcaUtworu>
{
    public void Configure(EntityTypeBuilder<WykonawcaUtworu> builder)
    {
        builder
            .HasKey(w => new
            {
                w.IdMuzyk,
                w.IdUtwor
            })
            .HasName("WykonwacaUtworu_pk");

        builder
            .Property(w => w.IdMuzyk)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(w => w.IdUtwor)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .HasOne(w => w.Muzyk)
            .WithMany(w => w.WykonawcyUtworow)
            .HasForeignKey(w => w.IdMuzyk)
            .HasConstraintName("WykonawcaUtworu_Muzyk")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(w => w.Utwor)
            .WithMany(w => w.WykonawcyUtworow)
            .HasForeignKey(w => w.IdUtwor)
            .HasConstraintName("WykonawcaUtworu_Utwor")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .ToTable("WykonawcaUtworu");
    }
}