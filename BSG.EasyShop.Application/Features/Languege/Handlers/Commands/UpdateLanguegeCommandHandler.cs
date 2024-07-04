using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Languege.Validators;
using BSG.EasyShop.Application.Features.Languege.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Commands
{
    public class UpdateLanguegeCommandHandler : IRequestHandler<UpdateLanguegeCommand, CommandResponse<string>>
    {
        private readonly ILanguegeRepository _languegeRepository;
        private readonly IMapper _mapper;

        public UpdateLanguegeCommandHandler(ILanguegeRepository languegeRepository, IMapper mapper)
        {
            _languegeRepository = languegeRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateLanguegeCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();

            #region Validation
            var validator = new LanguegeUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LanguegeUpdateDTO);
            #endregion
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            else
            {
                var languege = await _languegeRepository.GetItemByKey(request.Id);
                _mapper.Map(request.LanguegeUpdateDTO, languege);
                await _languegeRepository.Update(languege);
                response.Success = true;
                response.Message = "Update Successful.";
            }

            return response;
        }
    }
}
