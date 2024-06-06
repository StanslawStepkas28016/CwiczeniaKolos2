using Kolos2.ModelsDTO;

namespace Kolos2.Services;

public interface IMuzykaService
{
    public Task<MuzykDto> GetMuzykInformation(int idMuzyk, CancellationToken cancellationToken);

    public Task<int> AddMuzyk(MuzykWithUtworDto muzykWithUtworDto, CancellationToken cancellationToken);
}