using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.Languege.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Commands
{
    public class DeleteLanguegeCommandHandler : IRequestHandler<DeleteLanguegeCommand, BaseCommandResponse>
    {
        private readonly ILanguegeRepository _LanguegeRepository;
        private readonly IMapper _mapper;

        public DeleteLanguegeCommandHandler(ILanguegeRepository LanguegeRepository, IMapper mapper)
        {
            _LanguegeRepository = LanguegeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteLanguegeCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse { };
            var data = await _LanguegeRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {
                //throw new NotFoundException(nameof(data), request.Id);
                response.Success = false;
                response.Message = "Deletaion Failed.";
                response.Errors.Add("Item not found.");
            }
            #endregion

            else
            {

                await _LanguegeRepository.Remove(data);
                response.Id = data.Id;
                response.Success = true;
                response.Message = "Deletation Successful.";
            }
            return response;
        }
    }
}
