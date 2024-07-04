using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Languege.Validators;
using BSG.EasyShop.Application.Features.Languege.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Commands
{
    public class CreateLanguegeCommandHandler : IRequestHandler<CreateLanguegeCommand, CommandResponse<long>>
    {
        private readonly ILanguegeRepository _languegeRepository;
        private readonly IMapper _mapper;        

        public CreateLanguegeCommandHandler(ILanguegeRepository languegeRepository, IMapper mapper)
        {
            _languegeRepository = languegeRepository;
            _mapper = mapper;            
        }
        public async Task<CommandResponse<long>> Handle(CreateLanguegeCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new LanguegeCreateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LanguegeCreateDTO);

            if (validationResult.IsValid == false)
            {                
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var data = _mapper.Map<Domain.Languege>(request.LanguegeCreateDTO);
                await _languegeRepository.Add(data);

                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;
        }
    }
}
