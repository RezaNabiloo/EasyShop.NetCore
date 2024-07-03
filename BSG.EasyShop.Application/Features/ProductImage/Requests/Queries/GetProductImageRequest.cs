﻿using BSG.EasyShop.Application.DTOs.ProductImage;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductImage.Requests.Queries
{
    public class GetProductImageRequest : IRequest<ProductImageDTO>
    {
        public long Id { get; set; }
    }
}
