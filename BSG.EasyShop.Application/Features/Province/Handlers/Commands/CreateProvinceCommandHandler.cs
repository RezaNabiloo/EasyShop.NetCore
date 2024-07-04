using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Province.Validators;
using BSG.EasyShop.Application.Features.Province.Requests.Commands;
using BSG.EasyShop.Application.Models;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Commands
{
    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, CommandResponse<long>>
    {
        private readonly IProvinceRepository _ProvinceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateProvinceCommandHandler(IProvinceRepository ProvinceRepository, ICountryRepository countryRepository, IMapper mapper, IEmailSender emailSender)
        {
            _ProvinceRepository = ProvinceRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<CommandResponse<long>> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new ProvinceCreateDTOValidator(_countryRepository);
            var validationResult = await validator.ValidateAsync(request.ProvinceCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var data = _mapper.Map<Domain.Province>(request.ProvinceCreateDTO);
                await _ProvinceRepository.Add(data);

                response.Result= data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }

            return response;
        }
    }
}
