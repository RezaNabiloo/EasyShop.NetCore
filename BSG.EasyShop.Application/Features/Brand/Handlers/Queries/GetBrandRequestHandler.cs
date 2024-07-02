﻿using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Queries
{
    public class GetBrandRequestHandler : IRequestHandler<GetBrandRequest, BrandDTO>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BrandDTO> Handle(GetBrandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetItemByKey(request.Id);
            return _mapper.Map<BrandDTO>(brand);
        }
    }
}
