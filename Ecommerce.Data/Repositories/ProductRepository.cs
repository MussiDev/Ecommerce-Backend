using Dapper;
using Ecommerce.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public ProductRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            var db = dbConnection();

            var sql = @" DELETE FROM products WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { ID= product.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var db = dbConnection();

            var sql = @" SELECT id, product_name, price, category, subcategory, date_added, description FROM products";

            return await db.QueryAsync<Product>(sql, new { });
        }

        public async Task<Product> GetProduct(int id)
        {

            var db = dbConnection();

            var sql = @" SELECT id, product_name, price, category, subcategory, date_added, description
            FROM products
            Where id = @Id";

            return await db.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        public async Task<bool> InsertProduct(Product product)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO products (product_name,  price, category, subcategory, date_added, description) 
            VALUES (@Product_name, @Price, @Category, @Subcategory, @Date_added, @Description)";

            var result =  await db.ExecuteAsync(sql, new { product.Product_Name, product.Price, product.Category, product.SubCategory, product.Date_Added, product.Description});
            return result > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var db = dbConnection();

            var sql = @" UPDATE products 
            SET product_name = @Product_name,
                price = @Price, 
                category = @Category, 
                subcategory = @Subcategory, 
                date_added = @Date_added, 
                description = @Description
            WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { product.Product_Name, product.Price, product.Category, product.SubCategory, product.Date_Added, product.Description, product.Id });
            return result > 0;
        }
    }
}
