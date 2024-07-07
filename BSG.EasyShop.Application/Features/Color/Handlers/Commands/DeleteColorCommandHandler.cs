using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Color.Validators;
using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.Common.Validators;
using BSG.EasyShop.Application.Features.Color.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Commands
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, CommandResponse<string>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();           
            var color = await _colorRepository.GetItemByKey(request.Id);
            #region Validation            
            if (color == null)
            {

                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
            }
            #endregion
            else
            {
                await _colorRepository.Remove(color);
                response.Success = true;
                response.Message = "Creation Successful.";
            }


            //var validator = new ColorDeleteDTOValidator(_colorRepository);
            //var baseDTO = new BaseDTO { Id = request.Id };
            //var validationResult = await validator.ValidateAsync(baseDTO);

            //#region Validation            
            //if (validationResult.IsValid == false)
            //{
            //    response.Success = false;
            //    response.Message = "The deletion was failed.";
            //    response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            //}
            //#endregion
            //else
            //{
            //    await _colorRepository.Remove(data);
            //    response.Success = true;
            //    response.Message = "The deletion was successful.";
            //}
            return response;
        }
    }
}
