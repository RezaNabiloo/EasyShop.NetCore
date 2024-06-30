using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Color.Validators;
using BSG.EasyShop.Application.Features.Color.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Commands
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, BaseCommandResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;        

        public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;            
        }
        public async Task<BaseCommandResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse { };
            #region Validation
            var validator = new ColorCreateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ColorCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var data = _mapper.Map<Domain.Color>(request.ColorCreateDTO);
            await _colorRepository.Add(data);

            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";

            return response;
        }
    }
}
