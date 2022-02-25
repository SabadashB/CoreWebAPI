using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDAL
{
    public class ProductRepository
    {
        private static List<ProductDTO> _products;

        static ProductRepository()
        {
            _products = new List<ProductDTO>();
        }

        public Guid Add(ProductDTO product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);

            return product.Id;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _products;
        }

        public ProductDTO GetById(Guid id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public ProductDTO RemoveById(Guid id)
        {
            var entity = GetById(id);

            _products.Remove(entity);

            return entity;
        }

        public bool UpdateById(ProductDTO product)
        {
            var dbProduct = GetById(product.Id);
            if(dbProduct != null)
            {
                var index = _products.IndexOf(dbProduct);
                _products[index] = product;
            }

            return dbProduct != null;
        }
    }
}
