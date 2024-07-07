using AutoMapper;
using BSG.EasyShop.Application.DTOs.ProductGroup.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Commands
{
    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, CommandResponse<string>>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public UpdateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            #region Validation
            var validator = new ProductGroupUpdateDTOValidator(_productGroupRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupUpdateDTO);            
            if (validationResult.IsValid == false)            {
                response.Success = false;
                response.Message = "Editing was failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var productGroup = await _productGroupRepository.GetItemByKey(request.ProductGroupUpdateDTO.Id);
                if (productGroup == null)
                {
                    response.Success = false;
                    response.Message = "The deletion was failed.";
                    response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
                }
                else
                {
                    productGroup = _mapper.Map<Domain.ProductGroup>(request.ProductGroupUpdateDTO);
                    await _productGroupRepository.Update(productGroup);
                    response.Success = true;
                    response.Message = "Editing was done successfully.";
                }
            }
            return response;
            //return Unit.Value;  
        }
    }
}
