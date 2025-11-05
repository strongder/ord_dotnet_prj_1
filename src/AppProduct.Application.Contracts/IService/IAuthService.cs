using AppProduct.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.IService
{
    public interface IAuthService
    {
        Task<LoginResultDto> LoginAsync(LoginInputDto input);
        Task<string> RegisterAsync(RegisterDto input);
    }
}
