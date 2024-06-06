using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2.Entities.Configs;

public class MuzykEfConfig : IEntityTypeConfiguration<Muzyk>
{
    public void Configure(EntityTypeBuilder<Muzyk> builder)
    {
        /*// Ustawienie kolumny jako klucz główny.
        builder
            .HasKey(x => x.IdDoctor)
            .HasName("Doctor_pk");

        // Klucz nie jest auto generowany - nie jest IDENTITY.
        builder
            .Property(x => x.IdDoctor)
            .ValueGeneratedNever();

        // Pole FirstName, LastName i Email jest wymagane.
        builder
            .Property(x => x.FirstName)
            .IsRequired();

        builder
            .Property(x => x.LastName)
            .IsRequired();

        builder
            .Property(x => x.Email)
            .IsRequired();

        builder.ToTable("Doctor");*/

        builder
            .HasKey(m => m.IdMuzyk)
            .HasName("Muzyk_pk");

        builder
            .Property(m => m.IdMuzyk)
            .ValueGeneratedOnAdd();

        builder
            .Property(m => m.Imie)
            .IsRequired();

        builder
            .Property(m => m.Nazwisko)
            .IsRequired();

        builder
            .ToTable("Muzyk");
    }
}