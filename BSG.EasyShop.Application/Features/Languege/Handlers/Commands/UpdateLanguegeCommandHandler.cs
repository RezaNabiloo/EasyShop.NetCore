using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Languege.Validators;
using BSG.EasyShop.Application.Features.Languege.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Commands
{
    public class UpdateLanguegeCommandHandler : IRequestHandler<UpdateLanguegeCommand, BaseCommandResponse>
    {
        private readonly ILanguegeRepository _languegeRepository;
        private readonly IMapper _mapper;

        public UpdateLanguegeCommandHandler(ILanguegeRepository languegeRepository, IMapper mapper)
        {
            _languegeRepository = languegeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLanguegeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation
            var validator = new LanguegeUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.LanguegeUpdateDTO);
            #endregion
            if (validationResult.IsValid == true)
            {
                var languege = await _languegeRepository.GetItemByKey(request.Id);
                _mapper.Map(request.LanguegeUpdateDTO, languege);
                await _languegeRepository.Update(languege);

                response.Success = true;
                response.Message = "Update Successful.";
            }
            else
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
