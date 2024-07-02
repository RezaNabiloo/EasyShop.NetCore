using BSG.EasyShop.Application;
using BSG.EasyShop.Identity;
using BSG.EasyShop.Infrastructure;
using BSG.EasyShop.Persistence;

namespace BSG.EasyShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigurePersistenceServices(builder.Configuration);
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            //builder.Services.ConfigureIdentityServices(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // اینو غیر فعال میکنم و چون میخوام از توکن استفاده کنم در پایین سواگر رو کانفیگ کردم 
            // میبرمش داخل متد زیری و تنظیمات رو ست میکنم

            ////AddSwagger(builder.Services);

            builder.Services.AddCors(o =>
                {
                    o.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader());
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();

            ////app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.MapControllers();

            app.Run();



            ////void AddSwagger(IServiceCollection services)
            ////{
            ////    services.AddSwaggerGen(o =>
            ////    {
            ////        o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            ////        {
            ////            Description = @"JWT Authentication header using the Bearer schema.
            ////                            Enter 'Bearer' [scpae] and then your token in the text input below.
            ////                            Example : 'Bearer 123sddw'",
            ////            Name = "Authorization", 
            ////            In = ParameterLocation.Header,
            ////            Type = SecuritySchemeType.ApiKey,
            ////            Scheme = "Bearer"
            ////        });

            ////        o.AddSecurityRequirement(new OpenApiSecurityRequirement()
            ////        {
            ////            {
            ////                new OpenApiSecurityScheme()
            ////                {
            ////                    Reference = new OpenApiReference()
            ////                    {
            ////                        Type=ReferenceType.SecurityScheme,
            ////                        Id="Bearer"
            ////                    },
            ////                    Scheme="oauth2",
            ////                    Name="Bearer",
            ////                    In=ParameterLocation.Header
            ////                },
            ////                new List<string>()
            ////            }
            ////        });
            ////        o.SwaggerDoc("v1", new OpenApiInfo()
            ////        {
            ////            Version = "v1",
            ////            Title = "EasyShop Api",
            ////        });
            ////    });


            ////}


        }
    }
}