using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage.Validators;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Handlers.Commands
{
    public class UpdateProductGroupSizeCommandHandler : IRequestHandler<UpdateProductGroupSizeCommand, CommandResponse<string>>
    {
        private readonly IProductGroupSizeRepository _productGroupSizeRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public UpdateProductGroupSizeCommandHandler(IProductGroupSizeRepository productGroupSizeRepository, IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupSizeRepository = productGroupSizeRepository;
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateProductGroupSizeCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            #region Validation
            var validator = new ProductGroupSizeUpdateDTOValidator(_productGroupRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupSizeUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Editing was failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var productGroupSize = await _productGroupSizeRepository.GetItemByKey(request.ProductGroupSizeUpdateDTO.Id);
                if (productGroupSize == null)
                {
                    response.Success = false;
                    response.Message = "The deletion was failed.";
                    response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
                }
                else
                {
                    productGroupSize = _mapper.Map<Domain.ProductGroupSize>(request.ProductGroupSizeUpdateDTO);
                    await _productGroupSizeRepository.Update(productGroupSize);
                    response.Success = true;
                    response.Message = "Editing was done successfully.";
                }
            }
            return response;
        }
    }
}
