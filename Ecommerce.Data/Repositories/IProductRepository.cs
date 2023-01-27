using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<bool> InsertProduct (Product product);
        Task<bool> UpdateProduct (Product product);
        Task<bool> DeleteProduct (Product product);

    }
}
