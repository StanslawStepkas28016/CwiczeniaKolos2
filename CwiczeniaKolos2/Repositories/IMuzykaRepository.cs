using Kolos2.ModelsDTO;

namespace Kolos2.Repositories;

public interface IMuzykaRepository
{
    public Task<MuzykDto> GetMuzykInformation(int idMuzyk, CancellationToken cancellationToken);

    public Task<int> AddMuzyk(MuzykWithUtworDto muzykWithUtworDto, CancellationToken cancellationToken);
}