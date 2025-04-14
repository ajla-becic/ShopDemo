using AbySalto.Mid.Domain.Models;
using MediatR;

namespace AbySalto.Mid.Application.Queries
{
    public class GetBasketQuery : IRequest<List<BasketItem>?>
    {
        public int UserId { get; set; }
    }
}
