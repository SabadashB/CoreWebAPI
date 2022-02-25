using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDAL
{
    public interface IProductRepository
    {
        Guid Add(ProductDTO user);
        IEnumerable<ProductDTO> GetAll();
        ProductDTO GetById(Guid id);
        ProductDTO RemoveById(Guid id);
        bool UpdateById(ProductDTO user);
    }
}
