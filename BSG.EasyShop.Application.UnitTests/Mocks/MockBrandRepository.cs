using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Domain;
using Microsoft.VisualBasic;
using Moq;

namespace BSG.EasyShop.Application.UnitTests.Mocks
{
    public static class MockBrandRepository
    {
        // it will be return test or fake data 
        public static Mock<IBrandRepository> GetBrandRepository() 
        {
            var brands = new List<Domain.Brand>()
            {
                new Domain.Brand{ Id=1, FaTitle="اپل", EnTitle="Apple", ImagePath=""},
                new Domain.Brand{ Id=2, FaTitle="سامسونگ", EnTitle="Samsung", ImagePath=""}                
            };

            var mockRepository = new Mock<IBrandRepository>();

            // We want to do something, instead of fetching the information from the database, it fetches it from the mock that we created.
            // for this action we should setup mock

            // when i call 'GetAllItems()' return brands that i create in top, insted of brands list in database            
            mockRepository.Setup(t => t.GetAllItems()).ReturnsAsync(brands);

            // so we can add another setups . for example for add action.
            // when i call 'Add( new Brand)', if type is Brand the add Brand to brands in top and return inserted brand.
            mockRepository.Setup(t => t.Add(It.IsAny<Domain.Brand>())) 
                .ReturnsAsync((Domain.Brand brand) => { 
                    brands.Add(brand);
                    return brand;
                });
            

            return mockRepository;            
        }
    }
}
