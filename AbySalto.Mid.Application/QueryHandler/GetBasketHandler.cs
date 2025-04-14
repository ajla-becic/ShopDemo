using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Application.Queries;
using AbySalto.Mid.Domain.Models;
using MediatR;

namespace AbySalto.Mid.Application.QueryHandler
{
    public class GetBasketHandler : IRequestHandler<GetBasketQuery, List<BasketItem>?>
    {
        private readonly IUserRepository _userRepository;

        public GetBasketHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<BasketItem>?> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFullObjectById(request.UserId, cancellationToken);
            return user.Basket?.BasketItems?.ToList();
        }
    }
}
