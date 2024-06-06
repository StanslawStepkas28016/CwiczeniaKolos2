using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos2.Entities.Configs;

public class WytworniaEfConfig : IEntityTypeConfiguration<Wytwornia>
{
    public void Configure(EntityTypeBuilder<Wytwornia> builder)
    {
        builder
            .HasKey(w => w.IdWytwornia)
            .HasName("Wytwornia_pk");

        builder
            .Property(w => w.IdWytwornia)
            .ValueGeneratedOnAdd();

        builder
            .Property(w => w.Nazwa)
            .IsRequired();

        builder
            .ToTable("Wytwornia");
    }
}