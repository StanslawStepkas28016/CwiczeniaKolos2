namespace Kolos2.Entities;

public class WykonawcaUtworu
{
    public int IdMuzyk { get; set; }

    public int IdUtwor { get; set; }

    public virtual Muzyk Muzyk { get; set; }

    public virtual Utwor Utwor { get; set; }
}