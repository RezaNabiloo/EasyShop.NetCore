using BSG.EasyShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSG.EasyShop.Persistence.Configurations.Entities
{
    public class LanguegeConfiguration : IEntityTypeConfiguration<Languege>
    {
        public void Configure(EntityTypeBuilder<Languege> builder)
        {
            builder.HasData(
                new Languege { 
                    Id=1,
                    Title="پارسی",
                    OriginalTitle= "پارسی",
                    IsDefault=true                    
                },
                new Languege {
                    Id=2,
                    Title= "انگلیسی",
                    OriginalTitle="English",
                    IsDefault=false
                },
                new Languege
                {
                    Id = 3,
                    Title = "عربی",
                    OriginalTitle = "العربیه",
                    IsDefault = false
                }

                );
        }
    }
}
