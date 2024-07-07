using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Brand.Validators;
using BSG.EasyShop.Application.DTOs.Brand.Validators;
using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            var brand = await _brandRepository.GetItemByKey(request.Id);

            #region Validation            
            if (brand == null)
            {

                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
            }
            #endregion
            
            else
            {
                await _brandRepository.Remove(brand);
                response.Success = true;
                response.Message = "The deletion was successful.";
            }
            //var validator = new BrandDeleteDTOValidator(_brandRepository);
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
            //    await _brandRepository.Remove(data);
            //    response.Success = true;
            //    response.Message = "The deletion was successful.";
            //}
            return response;
        }
    }
}
