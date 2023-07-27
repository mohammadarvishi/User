using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Repository;

namespace User.Domain.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        public UserDBContext Context { get; }
        private IUsersRepository _IUsersRepository;
        public UnitOfWork(UserDBContext Contex)
        {
            Context = Contex;
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                if (_IUsersRepository == null)
                {
                    _IUsersRepository = new UsersRepository(this);
                }

                return _IUsersRepository;
            }
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}
