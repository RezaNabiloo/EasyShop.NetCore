using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroupSize.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Handlers.Commands
{
    public class CreateProductGroupSizeCommandHandler : IRequestHandler<CreateProductGroupSizeCommand, CommandResponse<long>>
    {
        private readonly IProductGroupSizeRepository _productGroupSizeRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public CreateProductGroupSizeCommandHandler(IProductGroupSizeRepository productGroupSizeRepository, IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupSizeRepository = productGroupSizeRepository;
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<long>> Handle(CreateProductGroupSizeCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new ProductGroupSizeCreateDTOValidator(_productGroupRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupSizeCreateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else {
                var data = _mapper.Map<Domain.ProductGroupSize>(request.ProductGroupSizeCreateDTO);
                data = await _productGroupSizeRepository.Add(data);
                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;

        }
    }
}
