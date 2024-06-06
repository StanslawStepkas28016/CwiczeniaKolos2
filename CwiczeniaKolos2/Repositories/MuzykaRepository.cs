using Kolos2.Entities;
using Kolos2.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Repositories;

public class MuzykaRepository : IMuzykaRepository
{
    private readonly MuzykaContext _context = new();

    public async Task<MuzykDto> GetMuzykInformation(int idMuzyk, CancellationToken cancellationToken)
    {
        if (await DoesMuzykExist(idMuzyk, cancellationToken) == false)
        {
            return new MuzykDto
            {
                IdMuzyk = -1
            };
        }

        var muzyk = await _context
            .Muzycy
            .Include(m => m.WykonawcyUtworow)
            .ThenInclude(wyk => wyk.Utwor)
            .Where(m => m.IdMuzyk == idMuzyk)
            .Select(m => new MuzykDto
            {
                IdMuzyk = m.IdMuzyk,
                Imie = m.Imie,
                Nazwisko = m.Nazwisko,
                Pseudonim = m.Pseudonim,
                Utwory = m.WykonawcyUtworow
                    .Select(wykonawcaUtworu => new UtworDto
                    {
                        IdUtwor = wykonawcaUtworu.Utwor.IdUtwor,
                        NazwaUtworu = wykonawcaUtworu.Utwor.NazwaUtworu,
                        CzasTrwania = wykonawcaUtworu.Utwor.CzasTrwania
                    }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);

        return muzyk!;
    }

    private async Task<bool> DoesMuzykExist(int idMuzyk, CancellationToken cancellationToken)
    {
        var res = await _context
            .Muzycy
            .Where(m => m.IdMuzyk == idMuzyk)
            .FirstOrDefaultAsync(cancellationToken);

        return res != null;
    }

    public async Task<int> AddMuzyk(MuzykWithUtworDto muzykWithUtworDto, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        if (IsProvidedUtworValid(muzykWithUtworDto.UtworWithoutKeyDto) == false)
        {
            return -1;
        }

        var utwor = new Utwor
        {
            NazwaUtworu = muzykWithUtworDto.UtworWithoutKeyDto.NazwaUtworu!,
            CzasTrwania = muzykWithUtworDto.UtworWithoutKeyDto.CzasTrwania
        };

        if (await DoesUtworExist(muzykWithUtworDto.UtworWithoutKeyDto, cancellationToken) == false)
        {
            await _context
                .Utwory
                .AddAsync(utwor, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            utwor = await _context
                .Utwory
                .Where(u => u.NazwaUtworu == muzykWithUtworDto.UtworWithoutKeyDto.NazwaUtworu)
                .FirstOrDefaultAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        var muzyk = new Muzyk
        {
            Imie = muzykWithUtworDto.Imie,
            Nazwisko = muzykWithUtworDto.Nazwisko,
            Pseudonim = muzykWithUtworDto.Pseudonim
        };

        await _context
            .Muzycy
            .AddAsync(muzyk, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        await _context
            .WykonawcyUtworow
            .AddAsync(new WykonawcaUtworu
            {
                IdMuzyk = muzyk.IdMuzyk,
                IdUtwor = utwor.IdUtwor
            }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return 1;
    }

    private bool IsProvidedUtworValid(UtworWithoutKeyDto utworWithoutKeyDto)
    {
        return utworWithoutKeyDto.NazwaUtworu != "string" && utworWithoutKeyDto.CzasTrwania != 0;
    }

    private async Task<bool> DoesUtworExist(UtworWithoutKeyDto utworWithoutKeyDto,
        CancellationToken cancellationToken)
    {
        var res = await _context
            .Utwory
            .Where(u =>
                u.NazwaUtworu == utworWithoutKeyDto.NazwaUtworu)
            .FirstOrDefaultAsync(cancellationToken);

        return res != null;
    }
}