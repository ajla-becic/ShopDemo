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

        public User(string? email, string? passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        public int Id { get; private set; }

        [Required]
        public string? Email { get; private set; }

        [Required]
        public string? PasswordHash { get; private set; }

        public ICollection<FavoriteCollectionItem> FavoriteCollectionItems { get; private set; } = [];
        public Basket? Basket { get; private set; } = new();
    }
}
