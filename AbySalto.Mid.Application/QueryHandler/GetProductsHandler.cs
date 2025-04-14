using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Application.Queries;
using MediatR;
using AbySalto.Mid.Application.DTO;

namespace AbySalto.Mid.Application.QueryHandler
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>?>
    {
        private readonly IExternalProductService _productService;

        public GetProductsHandler(IExternalProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<Product>?> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProductsAsync();
        }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IExternalProductService _productService;

        public GetProductByIdHandler(IExternalProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new InvalidOperationException("Id cannot be 0");
            }

            return await _productService.GetProductByIdAsync(request.Id);
        }
    }
}
