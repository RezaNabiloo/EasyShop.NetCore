using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Color.Validators;
using BSG.EasyShop.Application.Features.Color.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Commands
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CommandResponse<long>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;        

        public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;            
        }
        public async Task<CommandResponse<long>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long> { };
            #region Validation
            var validator = new ColorCreateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ColorCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage {MessageType= ResultMessageType.Error, Message= x.ErrorMessage } ).ToList();
            }
            #endregion
            else
            {
                var data = _mapper.Map<Domain.Color>(request.ColorCreateDTO);
                await _colorRepository.Add(data);

                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;
        }
    }
}
