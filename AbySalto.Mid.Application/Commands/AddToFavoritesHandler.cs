using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Domain.Interfaces;
using AbySalto.Mid.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Application.Commands
{
    public class AddToFavoritesHandler : IRequestHandler<AddToFavoritesCommand>
    {
        private readonly IRepository<FavoriteCollectionItem> _repository;

        public AddToFavoritesHandler(IRepository<FavoriteCollectionItem> repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddToFavoritesCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new FavoriteCollectionItem { ProductId = request.ProductId, UserId = request.UserId});
            await _repository.SaveChangesAsync();
        }
    }
}
