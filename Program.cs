
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WholeSaler.ApiProvider;
using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.Facade;
using WholeSaler.IRepository;
using WholeSaler.IService;
using WholeSaler.JWT;
using WholeSaler.Middleware;
using WholeSaler.Profiles;
using WholeSaler.Repository;
using WholeSaler.Seeder;
using WholeSaler.Service;

namespace WholeSaler
{
    public class Program
    {
        private const string MAIN_URL = "http://localhost:5173";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //seeder do zmiany
            new OpeningBalanceSeeder(new CoreContext()).seeder();
            //*****JwtSettings *****
            var authSettings = new AuthSettings();
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
            var config = configuration.Build();
            config.GetSection("Authentication").Bind(authSettings);

            builder.Services.AddSingleton(authSettings);
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authSettings.JwtIssuer,
                    ValidAudience = authSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.JwtKey))
                };
            });
            //*****JwtSettings *****



            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //repositories
            builder.Services.AddScoped<IAssortmentRepository, AssortmentRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ILocalisationRepository, LocalisationRepository>();
            builder.Services.AddScoped<IPaletteRepository, PaletteRepository>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ITransportRepository, TransportRepository>();
            builder.Services.AddScoped<IContractorRepository, ContractorRepository>();
            //services
            builder.Services.AddScoped<IAssortmentCrudService, AssortmentCrudService>();
            builder.Services.AddScoped<IOrderCrudService, OrderCrudService>();
            builder.Services.AddScoped<ILocalisationCrudService, LocalisationCrudService>();
            builder.Services.AddScoped<IPalleteCrudService, PaletteCrudService>();
            builder.Services.AddScoped<ICarCrudService, CarCrudService>();
            builder.Services.AddScoped<ITransportCrudService, TransportCrudService>();
            builder.Services.AddScoped<IUserAuthService, UserAuthService>();
            builder.Services.AddScoped<IUserContextService, UserContextService>();
            builder.Services.AddScoped<IOrderFacade, OrderFacade>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddScoped<IContractorCrudService, ContractorCrudService>();

            builder.Services.AddScoped<ICEIDGApiProvider, CEIDGApiProvider>();
          
            //other
            builder.Services.AddScoped<CoreContext>();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddScoped <IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<MainExceptionHandler>();

            //mapper profiles
            builder.Services.AddAutoMapper(typeof(AssortmentProfile));

            //enum conventer
            builder.Services.AddMvc().AddJsonOptions(opts => {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            var app = builder.Build();
            app.UseMiddleware<MainExceptionHandler>();
            app.UseCors(builder =>
            {
                builder.WithOrigins(MAIN_URL)
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
          
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            


            app.MapControllers();

            app.Run();
        }
    }
}