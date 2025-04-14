using AbySalto.Mid.Domain.Models;

namespace AbySalto.Mid.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
