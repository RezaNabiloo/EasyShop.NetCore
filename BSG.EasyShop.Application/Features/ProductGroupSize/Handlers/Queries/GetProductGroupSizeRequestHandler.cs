using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroupSize;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Handlers.Queries
{
    public class GetProductGroupSizeRequestHandler : IRequestHandler<GetProductGroupSizeRequest, ProductGroupSizeDTO>
    {
        private readonly IProductGroupSizeRepository _productGroupSizeRepository;
        private readonly IMapper _mapper;

        public GetProductGroupSizeRequestHandler(IProductGroupSizeRepository productGroupSizeRepository, IMapper mapper)
        {
            _productGroupSizeRepository = productGroupSizeRepository;
            _mapper = mapper;
        }

        public async Task<ProductGroupSizeDTO> Handle(GetProductGroupSizeRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGroupSizeRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProductGroupSizeDTO>(data);
        }
    }
}
