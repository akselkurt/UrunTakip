using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Core.Models;
using System.Data.Entity;

namespace UrunTakip.Core.Repository
{
    public class Transaction : Base<ProductsInfo>, ITransaction
    {
        public Transaction(MyContext context)
            :base(context)
        {

        }
        public async Task<List<ProductsInfo>> GetProductAsync(string qName)
        {
            try
            {
                var allProducts = dbSet.AsQueryable();
                if (qName != "" || qName != null)
                {
                    allProducts = allProducts.Where(x => x.QName == qName);
                }
                if (allProducts.Count() > 1000)
                {
                    allProducts = allProducts.Take(1000);
                }
                return await allProducts.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<bool> SaveProductAsync(List<ProductsInfo> products)
        {
            try
            {
                dbSet.AddRange(products);
                var result = await dbContext.SaveChangesAsync();
                return result > 0;
             }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        //public async Task<bool> IsLogin(string name,string password)
        //{
        //    try
        //    {
        //        dbse
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        

    }
}
