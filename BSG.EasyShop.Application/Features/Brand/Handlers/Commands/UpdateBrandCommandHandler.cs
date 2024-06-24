using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Brand.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Commands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Unit>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new BrandUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.BrandUpdateDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var brand = await _brandRepository.GetItemByKey(request.Id);
            _mapper.Map(request.BrandUpdateDTO, brand);
            await _brandRepository.Update(brand);
            return Unit.Value; 
        }
    }
}
