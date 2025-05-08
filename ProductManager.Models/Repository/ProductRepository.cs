using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerConsole.Models;


namespace ProductManagerConsole.Repository
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public bool Delete(int id)
        {
            int count = _products.RemoveAll(delegate(Product p)
            {
                return p.Id == id;
            });
            return count > 0;
        }

        public bool Update(Product updated)
        {
            int index = -1;

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == updated.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return false;

            _products[index] = updated;
            return true;
        }

        public Product GetById(int id)
        {
            foreach (Product p in _products)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public IEnumerable<Product> SearchByName(string keyword)
        {
            List<Product> result = new List<Product>();
            foreach (Product p in _products)
            {
                if (p.Name != null && p.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(p);
                }
            }
            return result;
        }
    }
}
