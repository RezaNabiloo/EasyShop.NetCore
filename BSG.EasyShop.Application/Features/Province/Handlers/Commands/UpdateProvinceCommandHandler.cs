using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Province.Validators;
using BSG.EasyShop.Application.Features.Province.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Commands
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand, CommandResponse<string>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public UpdateProvinceCommandHandler(IProvinceRepository ProvinceRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _provinceRepository = ProvinceRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();

            #region Validation
            var validator = new ProvinceUpdateDTOValidator(_countryRepository);
            var validationResult = await validator.ValidateAsync(request.ProvinceUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Editing was failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var province = await _provinceRepository.GetItemByKey(request.Id);
                if (province == null)
                {
                    response.Success = false;
                    response.Message = "Editing was failed.";
                    response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
                }
                else
                {
                    _mapper.Map(request.ProvinceUpdateDTO, province);
                    await _provinceRepository.Update(province);
                    response.Success = true;
                    response.Message = "Editing was done successfully.";
                }
            }
            return response;
        }
    }
}
