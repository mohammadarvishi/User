using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entity
{
    public class UserDB
    {
            [Key]
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Family { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
    }
}
