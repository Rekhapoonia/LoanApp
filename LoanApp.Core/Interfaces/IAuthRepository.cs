using LoanApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<ResponseDto> LoginAsync(LoginDto loginDto);
    }
}
