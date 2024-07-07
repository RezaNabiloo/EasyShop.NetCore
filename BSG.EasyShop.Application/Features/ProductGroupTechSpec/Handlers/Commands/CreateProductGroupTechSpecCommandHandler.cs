using AutoMapper;
using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Handlers.Commands
{
    public class CreateProductGroupTechSpecCommandHandler : IRequestHandler<CreateProductGroupTechSpecCommand, CommandResponse<long>>
    {
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IMapper _mapper;

        public CreateProductGroupTechSpecCommandHandler(IProductGroupTechSpecRepository productGroupTechSpecRepository, IMapper mapper)
        {
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<long>> Handle(CreateProductGroupTechSpecCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new ProductGroupTechSpecCreateDTOValidator(_productGroupTechSpecRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupTechSpecCreateDTO);
            #endregion
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            else
            {
                var data = _mapper.Map<Domain.ProductGroupTechSpec>(request.ProductGroupTechSpecCreateDTO);
                data = await _productGroupTechSpecRepository.Add(data);
                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;

        }
    }
}
