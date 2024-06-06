using Kolos2.ModelsDTO;
using Kolos2.Repositories;

namespace Kolos2.Services;

public class MuzykaService : IMuzykaService
{
    private IMuzykaRepository _hospitalRepository;

    public MuzykaService(IMuzykaRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }

    public async Task<MuzykDto> GetMuzykInformation(int idMuzyk, CancellationToken cancellationToken)
    {
        var res = await _hospitalRepository.GetMuzykInformation(idMuzyk, cancellationToken);

        return res;
    }

    public async Task<int> AddMuzyk(MuzykWithUtworDto muzykWithUtworDto, CancellationToken cancellationToken)
    {
        var res = await _hospitalRepository.AddMuzyk(muzykWithUtworDto, cancellationToken);

        return res;
    }
}