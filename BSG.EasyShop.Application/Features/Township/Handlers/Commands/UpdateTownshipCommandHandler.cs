using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Township.Validators;
using BSG.EasyShop.Application.Features.Township.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Handlers.Commands
{
    public class UpdateTownshipCommandHandler : IRequestHandler<UpdateTownshipCommand, BaseCommandResponse>
    {
        private readonly ITownshipRepository _townshipRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public UpdateTownshipCommandHandler(ITownshipRepository townshipRepository, IProvinceRepository provinceRepository, IMapper mapper)
        {
            _townshipRepository = townshipRepository;
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateTownshipCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation
            var validator = new TownshipUpdateDTOValidator(_provinceRepository);
            var validationResult = await validator.ValidateAsync(request.TownshipUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var township = await _townshipRepository.GetItemByKey(request.Id);
            _mapper.Map(request.TownshipUpdateDTO, township);
            await _townshipRepository.Update(township);

            
            response.Success = true;
            response.Message = "Update Successful.";
            return response; 
        }
    }
}
