using AutoMapper;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Commands
{
    public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand, Unit>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public DeleteProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
        {
            var data = await _productGroupRepository.GetItemByKey(request.Id);
            #region Validation            
            if (data == null)
            {
                throw new NotFoundException(nameof(data), request.Id);
            }
            #endregion
            await _productGroupRepository.Remove(data);
            return Unit.Value;
        }
    }
}
