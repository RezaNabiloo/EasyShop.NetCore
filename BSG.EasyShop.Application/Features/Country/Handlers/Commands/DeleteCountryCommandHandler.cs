using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.Country.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Commands
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, BaseCommandResponse>
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IMapper _mapper;

        public DeleteCountryCommandHandler(ICountryRepository CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse { };
            var data = await _CountryRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {
                //throw new NotFoundException(nameof(data), request.Id);
                response.Success = false;
                response.Message = "Deletaion Failed.";
                response.Errors.Add("Item not found.");
            }
            #endregion



            await _CountryRepository.Remove(data);
            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";

            return response;
        }
    }
}
