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
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Commands
{
    public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand, CommandResponse<string>>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public DeleteProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            var productGroup = await _productGroupRepository.GetItemByKey(request.Id);
            #region Validation            
            if (productGroup == null)
            {
                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not found." });
            }
            #endregion
            else {
                await _productGroupRepository.Remove(productGroup);
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            
            return response;
        }
    }
}
