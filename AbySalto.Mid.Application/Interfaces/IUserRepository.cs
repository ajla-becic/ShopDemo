using AbySalto.Mid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetFullObjectById(int id, CancellationToken cancellationToken);
        Task UpdateAndSaveAsync(User user, CancellationToken cancellationToken);
    }
}
