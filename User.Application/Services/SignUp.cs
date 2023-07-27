using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using User.Application.Interface;
using User.Domain.UnitOfWork;
using User.Domain.ViewModels;

namespace User.Application.Services
{
    public class SignUp:ISignUp
    {
        private readonly IUnitOfWork _uW;

        public SignUp(IUnitOfWork UW)
        {
            _uW = UW;
        }

        public async Task<string> CreatAsync(UserViewModel userViewModel)
        {
            var User = await _uW.UsersRepository.FindUserNameAsync(userViewModel.UserName);
            if (User == null)
            {
                var CreateUser = await _uW.UsersRepository.CreateAsync(userViewModel);
                if (CreateUser != null)
                {
                    return CreateUser;
                }
            }
            return null;
        }
    }
}
