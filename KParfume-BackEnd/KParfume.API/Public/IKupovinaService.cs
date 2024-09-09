using FluentResults;
using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IKupovinaService
    {
        Result<KupovinaDto> Create(KupovinaDto kupovinaDto);
        KupovinaDto Get(long id);
        Result<List<KupovinaDto>> GetAll();
        Result<List<KupovinaDto>> GetAllByUserId(long id);

    }
}
