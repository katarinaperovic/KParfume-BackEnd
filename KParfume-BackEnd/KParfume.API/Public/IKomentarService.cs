using FluentResults;
using KParfume.API.DTOs;

namespace KParfume.API.Public
{
    public interface IKomentarService
    {
        Result<KomentarDto> Create(KomentarDto komentarDto);
        KomentarDto Get(long id);
        Result<List<KomentarDto>> GetAll();
        Result<KomentarDto> Remove(long id);

    }
}
