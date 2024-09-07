using FluentResults;
using KParfume.API.DTOs;

namespace KParfume.API.Public
{
    public interface IKuponService
    {
        Result<KuponDto> Create(KuponDto kuponDto);
        KuponDto Get(long id);
        Result<List<KuponDto>> GetAll();
        Result<KuponDto> Remove(long id);
      

    }
}
