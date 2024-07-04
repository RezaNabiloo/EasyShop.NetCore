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
    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, CommandResponse<long>>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public CreateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<long>> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new ProductGroupCreateDTOValidator(_productGroupRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupCreateDTO);
            #endregion
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            else
            {
                var data = _mapper.Map<Domain.ProductGroup>(request.ProductGroupCreateDTO);
                data = await _productGroupRepository.Add(data);
                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;

        }
    }
}
