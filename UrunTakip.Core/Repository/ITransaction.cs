using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Core.Models;

namespace UrunTakip.Core.Repository
{
    public interface ITransaction : IBase<ProductsInfo>
    {
        Task<bool> SaveProductAsync(List<ProductsInfo> products);
        Task<List<ProductsInfo>> GetProductAsync(string qName);
        
    }
}
