using KParfume.API.DTOs;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface IUserService
    {
        Result<UserDto> GetById(long userId);
    }
}
