using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Languege.Validators;
using BSG.EasyShop.Application.Features.Languege.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Commands
{
    public class CreateLanguegeCommandHandler : IRequestHandler<CreateLanguegeCommand, BaseCommandResponse>
    {
        private readonly ILanguegeRepository _languegeRepository;
        private readonly IMapper _mapper;        

        public CreateLanguegeCommandHandler(ILanguegeRepository languegeRepository, IMapper mapper)
        {
            _languegeRepository = languegeRepository;
            _mapper = mapper;            
        }
        public async Task<BaseCommandResponse> Handle(CreateLanguegeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse { };
            #region Validation
            var validator = new LanguegeCreateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LanguegeCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion
            else
            {
                var data = _mapper.Map<Domain.Languege>(request.LanguegeCreateDTO);
                await _languegeRepository.Add(data);

                response.Id = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;
        }
    }
}
