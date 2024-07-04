using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage.Validators;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
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
                response.Message = "Update failed";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var data = await _productGroupSizeRepository.GetItemByKey(request.ProductGroupSizeUpdateDTO.Id);
                data = _mapper.Map<Domain.ProductGroupSize>(request.ProductGroupSizeUpdateDTO);
                await _productGroupSizeRepository.Update(data);
                response.Success = true;
                response.Message = "Update Successful.";
            }
            return response;
        }
    }
}
