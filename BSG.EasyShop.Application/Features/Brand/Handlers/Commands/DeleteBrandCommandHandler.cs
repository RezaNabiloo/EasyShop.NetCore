using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Commands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {


            var data = await _brandRepository.GetItemByKey(request.Id);

            #region Validation            
            if (data == null)
            {
                throw new NotFoundException(nameof(data), request.Id);
            }
            #endregion

            await _brandRepository.Remove(data);
            return Unit.Value;
        }
    }
}
