using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Core.Models;

namespace UrunTakip.Core.Repository
{
    public class UserRepository : Base<UserInfo>, IUserRepository
    {
        public UserRepository(MyContext context)
          : base(context)
        {

        }

        public async Task<object[]> UserLogin(string personelName, string password)
        {
            var userData = await dbSet.FirstOrDefaultAsync(x => x.PersonelName == personelName && x.Password == password);
            object[] roleanduserId = new object[3];
            if (string.IsNullOrEmpty(personelName) == true || string.IsNullOrEmpty(password) == true)
            {

                return null;
            }
            else
            {
                if (userData != null)
                {
                    roleanduserId[0] = userData.PersonelName;
                    roleanduserId[1] = userData.Id;
                    roleanduserId[2] = userData.RoleId;
                    return roleanduserId;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
