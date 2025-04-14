using AbySalto.Mid.Application.Commands;
using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Interfaces;
using AbySalto.Mid.Domain.Models;
using MediatR;

namespace AbySalto.Mid.Application.CommandHandlers
{
    public class AddToBasketHandler : IRequestHandler<AddToBasketCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Basket> _basketRepository;

        public AddToBasketHandler(IUserRepository userRepository, IRepository<Basket> basketRepocitory)
        {
            _userRepository = userRepository;
            _basketRepository = basketRepocitory;
        }

        public async Task<bool> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
           var user = await _userRepository.GetFullObjectById(request.UserId, cancellationToken);

            if (user?.Id == null)
            {
                return false;
            }

            var existing = user.Basket?.BasketItems.FirstOrDefault(c => c.ProductId == request.ProductId);
            if (existing != null)
            {
                existing.Quantity += request.Quantity;
            }
            else
            {
                user.Basket?.BasketItems.Add(new BasketItem { ProductId = request.ProductId, Quantity = request.Quantity });
                if (user.Basket?.Id == 0)
                {
                    user.Basket.UserId = user.Id;
                    await _basketRepository.AddAsync(user.Basket);
                }
                else
                {
                    _basketRepository.Update(user.Basket);
                }
            }

            await _userRepository.UpdateAndSaveAsync(user, cancellationToken);
            await _basketRepository.SaveChangesAsync();

            return true;
        }
    }
}
