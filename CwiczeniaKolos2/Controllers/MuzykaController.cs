using Kolos2.ModelsDTO;
using Kolos2.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MuzykaController : ControllerBase
{
    private IMuzykaService _muzykaService;

    public MuzykaController(IMuzykaService muzykaService)
    {
        _muzykaService = muzykaService;
    }

    [HttpGet("GetMuzykInformation")]
    public async Task<IActionResult> GetMuzykInformation(int idMuzyk, CancellationToken cancellationToken)
    {
        var res = await _muzykaService.GetMuzykInformation(idMuzyk, cancellationToken);

        if (res.IdMuzyk == -1)
        {
            return NotFound("Muzyk nie istnieje w bazie!");
        }

        return Ok(res);
    }

    [HttpPut("AddMuzykWithOptionalUtwor")]
    public async Task<IActionResult> AddMuzyk(MuzykWithUtworDto muzykWithUtworDto, CancellationToken cancellationToken)
    {
        var res = await _muzykaService.AddMuzyk(muzykWithUtworDto, cancellationToken);

        if (res == -1)
        {
            return Content("Nie można dodać bez podanego utworu!");
        }

        return Ok("Dodano muzyka!");
    }
}