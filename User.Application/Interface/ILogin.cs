using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.ViewModels;

namespace User.Application.Interface
{
    public interface ILogin
    {
        Task<string> LoginAsync(LoginViewModel loginViewModel);
    }
}
