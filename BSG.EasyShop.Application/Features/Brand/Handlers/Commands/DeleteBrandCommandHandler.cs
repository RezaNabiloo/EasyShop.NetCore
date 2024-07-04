using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Commands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, CommandResponse<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {

            var response = new CommandResponse<string>();
            var data = await _brandRepository.GetItemByKey(request.Id);

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
                await _brandRepository.Remove(data);             
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            return response;
        }
    }
}
