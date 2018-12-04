using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Core.Models;

namespace UrunTakip.Core.Repository
{
   public interface IUserRepository : IBase<Users>
    {
        Task<object[]> UserLogin(string personelName, string password);
    }
}
