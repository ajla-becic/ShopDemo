using AbySalto.Mid.Domain.Models;
using MediatR;
using AbySalto.Mid.Application.DTO;

namespace AbySalto.Mid.Application.Queries
{
    public class GetProductsQuery : IRequest<List<Product>> 
    {
        public int Page { get; set; } = 1;        
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public bool SortDesc { get; set; } = false;
    }

    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
