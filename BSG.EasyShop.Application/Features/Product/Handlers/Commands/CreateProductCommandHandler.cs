using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Product.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResponse<long>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IBrandRepository brandRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new ProductCreateDTOValidator(_productGroupRepository, _brandRepository);
            var validationResult = await validator.ValidateAsync(request.ProductCreateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var data = _mapper.Map<Domain.Product>(request.ProductCreateDTO);
                data = await _productRepository.Add(data);
                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;
        }
    }
}
