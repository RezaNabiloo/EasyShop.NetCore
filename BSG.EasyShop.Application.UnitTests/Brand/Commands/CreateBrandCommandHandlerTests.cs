using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Features.Brand.Handlers.Commands;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Application.Profiles;
using BSG.EasyShop.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace BSG.EasyShop.Application.UnitTests.Brand.Commands
{
    public class CreateBrandCommandHandlerTests
    {
        Mock<IBrandRepository> _mockRepository;
        IMapper _mapper;
        IEmailSender _emailSender;
        BrandCreateDTO _brandCreateBrandDTO;
        public CreateBrandCommandHandlerTests()
        {
            _mockRepository = MockBrandRepository.GetBrandRepository();

            // config for mapper  
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<BrandMappingProfile>();
            });
            // set _mapper configuration.
            _mapper = mapperConfig.CreateMapper();

            // we can create this object in body. but for make easy i create this in constractor
            _brandCreateBrandDTO = new BrandCreateDTO
            {
                Title = "ال جی",                
                ImagePath = ""
            };
        }


        [Fact]
        public async Task CreateBrandTest()
        {
            var handler = new CreateBrandCommandHandler(_mockRepository.Object, _mapper, _emailSender);

            var result = await handler.Handle(new CreateBrandCommand() { BrandCreateDTO = _brandCreateBrandDTO }, CancellationToken.None);

            result.ShouldBeOfType<CommandResponse<long>>();

            var brands = await _mockRepository.Object.GetAllItems();
            //brands.Count.ShouldBe(4);
            brands.Count.ShouldBe(3);





        }

    }
}
