using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Color.Validators;
using BSG.EasyShop.Application.Features.Color.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Commands
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, BaseCommandResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation
            var validator = new ColorUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ColorUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var color = await _colorRepository.GetItemByKey(request.Id);
            _mapper.Map(request.ColorUpdateDTO, color);
            await _colorRepository.Update(color);

            
            response.Success = true;
            response.Message = "Update Successful.";
            return response; 
        }
    }
}
