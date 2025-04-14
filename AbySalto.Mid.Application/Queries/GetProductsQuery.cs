using AbySalto.Mid.Domain.Models;
using MediatR;
using AbySalto.Mid.Application.DTO;

namespace AbySalto.Mid.Application.Queries
{
    public class GetProductsQuery : IRequest<List<Product>> { }

    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
