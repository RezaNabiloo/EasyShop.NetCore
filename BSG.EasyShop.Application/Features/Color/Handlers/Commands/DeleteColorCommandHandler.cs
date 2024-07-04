using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.Color.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Commands
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, CommandResponse<string>>
    {
        private readonly IColorRepository _ColorRepository;
        private readonly IMapper _mapper;

        public DeleteColorCommandHandler(IColorRepository ColorRepository, IMapper mapper)
        {
            _ColorRepository = ColorRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {

            var response = new CommandResponse<string>();
            var data = await _ColorRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {                
                response.Success = false;
                response.Message = "Deletaion Failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item not found." });                
            }
            #endregion

            else
            {

                await _ColorRepository.Remove(data);
                response.Success = true;
                response.Message = "Deletation Successful.";
            }
            return response;
        }
    }
}
