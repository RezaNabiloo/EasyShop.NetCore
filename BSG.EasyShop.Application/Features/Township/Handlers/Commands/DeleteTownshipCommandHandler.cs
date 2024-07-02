using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Township.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Handlers.Commands
{
    public class DeleteTownshipCommandHandler : IRequestHandler<DeleteTownshipCommand, BaseCommandResponse>
    {
        private readonly ITownshipRepository _TownshipRepository;
        private readonly IMapper _mapper;

        public DeleteTownshipCommandHandler(ITownshipRepository TownshipRepository, IMapper mapper)
        {
            _TownshipRepository = TownshipRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteTownshipCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse { };
            var data = await _TownshipRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {
                //throw new NotFoundException(nameof(data), request.Id);
                response.Success = false;
                response.Message = "Deletaion Failed.";
                response.Errors.Add("Item not found.");
            }
            #endregion



            await _TownshipRepository.Remove(data);
            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";

            return response;
        }
    }
}
