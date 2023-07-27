using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Repository;

namespace User.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();
        UserDBContext Context { get; }
        IUsersRepository UsersRepository { get; }
    }
}
