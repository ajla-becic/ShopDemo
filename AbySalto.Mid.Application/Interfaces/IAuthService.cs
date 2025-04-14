using AbySalto.Mid.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthorisationResponse> RegisterAsync(RegisterRequest request);
        Task<AuthorisationResponse> LoginAsync(LoginRequest request);
    }
}
