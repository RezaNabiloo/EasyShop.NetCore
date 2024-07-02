using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Province.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Commands
{
    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, BaseCommandResponse>
    {
        private readonly IProvinceRepository _ProvinceRepository;
        private readonly IMapper _mapper;

        public DeleteProvinceCommandHandler(IProvinceRepository ProvinceRepository, IMapper mapper)
        {
            _ProvinceRepository = ProvinceRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse { };
            var data = await _ProvinceRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {
                //throw new NotFoundException(nameof(data), request.Id);
                response.Success = false;
                response.Message = "Deletaion Failed.";
                response.Errors.Add("Item not found.");
            }
            #endregion



            await _ProvinceRepository.Remove(data);
            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";

            return response;
        }
    }
}
