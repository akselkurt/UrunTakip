using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Core.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string PersonelName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

    }
}
