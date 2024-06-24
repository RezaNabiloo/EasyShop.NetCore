using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Features.Brand.Handlers.Queries;
using BSG.EasyShop.Application.Features.Brand.Requests.Queries;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using BSG.EasyShop.Application.Profiles;
using BSG.EasyShop.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace BSG.EasyShop.Application.UnitTests.Brand.Queries
{
    /// <summary>
    /// Testing Brand Queries in Application.Features.Brand.Queries
    /// </summary>
    public class GetBrandListRequestHandlerTests
    {
        Mock<IBrandRepository> _mockRepository;
        IMapper _mapper;
        
        public GetBrandListRequestHandlerTests()
        {
            _mockRepository = MockBrandRepository.GetBrandRepository();

            // config for mapper  
            var mapperConfig = new MapperConfiguration(m => {
                m.AddProfile<BrandMappingProfile>();
            });
            // set _mapper configuration.
            _mapper = mapperConfig.CreateMapper();
        }



        [Fact]
        public async Task GetBrandListTest() 
        {
            var handler = new GetBrandListRequestHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetBrandListRequest(), CancellationToken.None);

            // Test
            result.ShouldBeOfType<List<BrandListDTO>>();
            result.Count.ShouldBe(2);


        }
    }
}
