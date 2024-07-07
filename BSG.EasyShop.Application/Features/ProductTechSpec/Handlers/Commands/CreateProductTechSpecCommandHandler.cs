using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductTechSpec.Validators;
using BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Handlers.Commands
{
    public class CreateProductTechSpecCommandHandler : IRequestHandler<CreateProductTechSpecCommand, CommandResponse<long>>
    {
        private readonly IProductTechSpecRepository _productTechSpecRepository;
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductTechSpecCommandHandler(IProductTechSpecRepository productTechSpecRepository,IProductGroupTechSpecRepository productGroupTechSpecRepository, IProductRepository productRepository, IMapper mapper)
        {
            _productTechSpecRepository = productTechSpecRepository;
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<long>> Handle(CreateProductTechSpecCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new ProductTechSpecCreateDTOValidator(_productRepository, _productGroupTechSpecRepository);
            var validationResult = await validator.ValidateAsync(request.ProductTechSpecCreateDTO);
            #endregion
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            else
            {
                var data = _mapper.Map<Domain.ProductTechSpec>(request.ProductTechSpecCreateDTO);
                data = await _productTechSpecRepository.Add(data);
                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;

        }
    }
}
