using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Models
{
    [Table("Product")]
    public class Product
    {
        public int  Id { get; set; }
        public string? Title { get; set; } 
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
