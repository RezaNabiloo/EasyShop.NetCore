using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Province.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Province.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Commands
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand, BaseCommandResponse>
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
        public async Task<BaseCommandResponse> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation
            var validator = new ProvinceUpdateDTOValidator(_countryRepository);
            var validationResult = await validator.ValidateAsync(request.ProvinceUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var Province = await _provinceRepository.GetItemByKey(request.Id);
            _mapper.Map(request.ProvinceUpdateDTO, Province);
            await _provinceRepository.Update(Province);

            
            response.Success = true;
            response.Message = "Update Successful.";
            return response; 
        }
    }
}
