using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.Country.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Commands
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, CommandResponse<string>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public DeleteCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {

            var response = new CommandResponse<string>();
            var country = await _countryRepository.GetItemByKey(request.Id);
            
            #region Validation            
            if (country== null)
            {
                response.Success = false;
                response.Message = "Deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
            }
            #endregion
            else
            {
                await _countryRepository.Remove(country);
                response.Success = true;
                response.Message = "The deletion was Successful.";
            }
            return response;
        }
    }
}
