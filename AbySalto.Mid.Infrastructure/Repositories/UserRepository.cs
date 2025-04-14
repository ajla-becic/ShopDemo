using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Models;
using AbySalto.Mid.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ShopDbContext _shopDbContext;
        public UserRepository(ShopDbContext context) : base(context)
        {
            _shopDbContext = context;
        }

        public async Task<User> GetFullObjectById(int id, CancellationToken cancellationToken)
        {
            return await _shopDbContext.Users.Include(u => u.Basket).ThenInclude(b => b.BasketItems).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAndSaveAsync(User user, CancellationToken cancellationToken)
        {
            _shopDbContext.Entry(user).State = EntityState.Modified;
            await _shopDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
