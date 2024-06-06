using Kolos2.Entities;

namespace Kolos2.ModelsDTO;

public class MuzykWithUtworDto
{
    public string Imie { get; set; }

    public string Nazwisko { get; set; }

    public string Pseudonim { get; set; }

    public UtworWithoutKeyDto UtworWithoutKeyDto { get; set; }
}