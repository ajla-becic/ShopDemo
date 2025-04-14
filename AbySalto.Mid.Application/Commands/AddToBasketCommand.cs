using MediatR;

namespace AbySalto.Mid.Application.Commands
{
    public class AddToBasketCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
