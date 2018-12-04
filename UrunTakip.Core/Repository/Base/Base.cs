using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunTakip.Core.Repository
{
    public class Base<T> : IBase<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;
        public Base(DbContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<T>();
        }
        public virtual T GetById(int id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }
        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return dbSet.AsEnumerable<T>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
