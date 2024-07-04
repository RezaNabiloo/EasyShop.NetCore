using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Township.Validators;
using BSG.EasyShop.Application.Features.Township.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Handlers.Commands
{
    public class CreateTownshipCommandHandler : IRequestHandler<CreateTownshipCommand, CommandResponse<long>>
    {
        private readonly ITownshipRepository _townshipRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public CreateTownshipCommandHandler(ITownshipRepository townshipRepository, IProvinceRepository provinceRepository, IMapper mapper)
        {
            _townshipRepository = townshipRepository;
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<long>> Handle(CreateTownshipCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new TownshipCreateDTOValidator(_provinceRepository);
            var validationResult = await validator.ValidateAsync(request.TownshipCreateDTO);
            #endregion
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            else
            {
                var data = _mapper.Map<Domain.Township>(request.TownshipCreateDTO);
                await _townshipRepository.Add(data);
                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }

            return response;
        }
    }
}
