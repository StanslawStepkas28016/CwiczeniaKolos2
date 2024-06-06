using Kolos2.Entities;

namespace Kolos2.ModelsDTO;

public class MuzykDto
{
    public int IdMuzyk { get; set; }

    public string Imie { get; set; }

    public string Nazwisko { get; set; }

    public string Pseudonim { get; set; }

    public List<UtworDto> Utwory { get; set; } = new List<UtworDto>();
}