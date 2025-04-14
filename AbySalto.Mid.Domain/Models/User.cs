using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; private set; }

        [Required]
        public string? Email { get; private set; }

        [Required]
        public string? PasswordHash { get; private set; }

        //public ICollection<Product> FavoriteProductIds { get; private set; } = [];
        public Basket? Basket { get; private set; } = new();

        public void RemoveFromBasket(int productId)
        {
            var item = Basket.BasketItems.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
                Basket.BasketItems.Remove(item);
        }
    }
}
