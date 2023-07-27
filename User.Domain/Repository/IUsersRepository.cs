using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entity;
using User.Domain.ViewModels;

namespace User.Domain.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<UserDB>> FindAllAsync();
        Task<string> CreateAsync(UserViewModel userViewModel);
        Task<bool> LoginAsync(LoginViewModel loginViewModel);
        Task<UserDB> FindUserNameAsync(string UserName);
        Task<UserDB> FindIdAsync(Guid id);
    }
}
