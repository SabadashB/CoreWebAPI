using AutoMapper;
using CoreBL.Models;
using CoreDAL;
using CoreDAL.Entities;
using System;
using System.Collections.Generic;

namespace CoreBL
{
    public class ProductService
    {
        private ProductRepository _productRepasetory;
        private IMapper _mapper;

        public ProductService(
            IMapper mapper,
            ProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepasetory = new ProductRepository();
        }

        public Guid AddProduct(Product product)
        {
            if (!char.IsUpper(product.Name[0]))
            {
                throw new ArgumentException("Name should start with upper-сase!");
            }

            var DBProduct = _mapper.Map<ProductDTO>(product);

            return _productRepasetory.Add(DBProduct);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var dbItems = _productRepasetory.GetAll();

            return _mapper.Map<IEnumerable<Product>>(dbItems);
        }

        public Product GetProductByID(Guid id)
        {
            var dbUser = _productRepasetory.GetById(id);

            return _mapper.Map<Product>(dbUser);
        }

        public Product RemoveProduct(Guid id)
        {
            var dbProduct = _productRepasetory.RemoveById(id);

            return _mapper.Map<Product>(dbProduct);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepasetory.UpdateById(_mapper.Map<ProductDTO>(product));
        }
    }
}
