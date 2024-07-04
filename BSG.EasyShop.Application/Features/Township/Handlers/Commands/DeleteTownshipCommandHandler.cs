using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Township.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Handlers.Commands
{
    public class DeleteTownshipCommandHandler : IRequestHandler<DeleteTownshipCommand, CommandResponse<string>>
    {
        private readonly ITownshipRepository _townshipRepository;
        private readonly IMapper _mapper;

        public DeleteTownshipCommandHandler(ITownshipRepository townshipRepository, IMapper mapper)
        {
            _townshipRepository = townshipRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteTownshipCommand request, CancellationToken cancellationToken)
        {

            var response = new CommandResponse<string>();
            var data = await _townshipRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {
                //throw new NotFoundException(nameof(data), request.Id);
                response.Success = false;
                response.Message = "Deletaion Failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item not found." });
            }
            #endregion
            else
            {
                await _townshipRepository.Remove(data);
                response.Success = true;
                response.Message = "Deletation Successful.";
            }
            return response;
        }
    }
}
