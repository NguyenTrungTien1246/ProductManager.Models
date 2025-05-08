using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerConsole.Models;
namespace ProductManagerConsole.Factory
{
    public static class ProductFactory
    {
        private static int _nextId = 1;

        public static Product CreateProduct(string name, Category category, Supplier supplier)
        {
            return new Product
            {
                Id = _nextId++,
                Name = name,
                Category = category,
                Supplier = supplier
            };
        }
    }
}
