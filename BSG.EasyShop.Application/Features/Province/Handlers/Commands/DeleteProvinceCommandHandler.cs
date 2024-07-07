using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Province.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Commands
{
    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, CommandResponse<string>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public DeleteProvinceCommandHandler(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
        {

            var response = new CommandResponse<string>();
            var data = await _provinceRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {

                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
            }
            #endregion
            else
            {
                await _provinceRepository.Remove(data);
                response.Success = true;
                response.Message = "The deletion was successful.";
            }
            return response;
        }
    }
}
