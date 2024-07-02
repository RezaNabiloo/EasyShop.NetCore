using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.Color.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Commands
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, BaseCommandResponse>
    {
        private readonly IColorRepository _ColorRepository;
        private readonly IMapper _mapper;

        public DeleteColorCommandHandler(IColorRepository ColorRepository, IMapper mapper)
        {
            _ColorRepository = ColorRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse { };
            var data = await _ColorRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {
                //throw new NotFoundException(nameof(data), request.Id);
                response.Success = false;
                response.Message = "Deletaion Failed.";
                response.Errors.Add("Item not found.");
            }
            #endregion



            await _ColorRepository.Remove(data);
            response.Id = data.Id;
            response.Success = true;
            response.Message = "Deletation Successful.";

            return response;
        }
    }
}
