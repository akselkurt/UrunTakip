using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Core.Models;

namespace UrunTakip.Core
{
    public class MyContext: DbContext
    {
        //public IDbSet<ProductsInfo> ProductsInfo { get; set; }
        //public IDbSet<UserInfo> UserInfo { get; set; }
        public MyContext() : base("UrunTakipContext")
        {
            this.Database.CommandTimeout = 180;
        }
        public virtual DbSet<ProductsInfo> ProductsInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}
