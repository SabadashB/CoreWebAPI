using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core1WebAPI.Models
{
    public class Product
    {
        [KeyAttribute]
        public Guid Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateTime ArrivedDate { get; set; }

    }
}
