using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Brand.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Commands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, CommandResponse<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();

            #region Validation
            var validator = new BrandUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.BrandUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var brand = await _brandRepository.GetItemByKey(request.Id);
                _mapper.Map(request.BrandUpdateDTO, brand);
                await _brandRepository.Update(brand);
                response.Success = true;
                response.Message = "Update Successful.";
            }
            return response; 
        }
    }
}
