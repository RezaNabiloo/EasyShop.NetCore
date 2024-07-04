using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.Languege.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Commands
{
    public class DeleteLanguegeCommandHandler : IRequestHandler<DeleteLanguegeCommand, CommandResponse<string>>
    {
        private readonly ILanguegeRepository _languegeRepository;
        private readonly IMapper _mapper;

        public DeleteLanguegeCommandHandler(ILanguegeRepository languegeRepository, IMapper mapper)
        {
            _languegeRepository = languegeRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteLanguegeCommand request, CancellationToken cancellationToken)
        {

            var response = new CommandResponse<string>();
            var data = await _languegeRepository.GetItemByKey(request.Id);

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

                await _languegeRepository.Remove(data);                
                response.Success = true;
                response.Message = "Deletation Successful.";
            }
            return response;
        }
    }
}
