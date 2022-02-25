using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDAL.Entities
{
    public class ProductDTO
    {
        [KeyAttribute]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public DateTime ArrivedDate { get; set; }

    }
}
