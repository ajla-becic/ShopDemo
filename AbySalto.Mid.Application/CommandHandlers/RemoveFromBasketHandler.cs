using AbySalto.Mid.Application.Commands;
using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Interfaces;
using AbySalto.Mid.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Application.CommandHandlers
{
    public class RemoveFromBasketHandler : IRequestHandler<RemoveFromBasketCommand>
    {
        private readonly IRepository<BasketItem> _basketItemRepository;

        public RemoveFromBasketHandler(IRepository<BasketItem> basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }

        public async Task Handle(RemoveFromBasketCommand request, CancellationToken cancellationToken)
        {
            var basketItem = await _basketItemRepository.GetByIdAsync(request.BasketItemId);

            if (basketItem == null) { return; }

            _basketItemRepository.Delete(basketItem);

            await _basketItemRepository.SaveChangesAsync();
        }
    }
}
