using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Models
{
    [Table("Basket")]
    public class Basket
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public ICollection<BasketItem> BasketItems { get; private set; } = [];
    }
}
