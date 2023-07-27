using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface;
using User.Domain.UnitOfWork;
using User.Domain.ViewModels;

namespace User.Application.Services
{
    public class Login:ILogin
    {
        private readonly IUnitOfWork _uW;

        public Login(IUnitOfWork UW)
        {
            _uW = UW;
        }
        public async Task<string> LoginAsync(LoginViewModel loginViewModel)
        {
            var User = await _uW.UsersRepository.FindUserNameAsync(loginViewModel.UserName);
            if (User != null)
            {
                if (User.Password == loginViewModel.Password)
                {
                    return User.Id.ToString();
                }
                else
                { return null; }
            }
            return null;
        }
    }
}
