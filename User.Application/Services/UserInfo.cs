using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface;
using User.Domain.Entity;
using User.Domain.UnitOfWork;
using User.Domain.ViewModels;

namespace User.Application.Services
{
    public class UserInfo:IUserInfo
    {
        private readonly IUnitOfWork _uW;

        public UserInfo(IUnitOfWork UW)
        {
            _uW = UW;
        }
        public async Task<UserViewModel> Info(string UserId)
        {
            var User = await _uW.UsersRepository.FindIdAsync(new Guid(UserId));
            UserViewModel userViewModel = new UserViewModel()
            {
                UserName = User.UserName,
                Family = User.Family,
                Name = User.Name,
                Password = User.Password
            };
            return userViewModel;
        }
    }
}
