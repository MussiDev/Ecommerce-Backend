using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public DateTime Date_Added { get; set; }
    }
}
