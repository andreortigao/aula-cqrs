using ExemploHexagonal.AdapterInHttp;
using ExemploHexagonal.AdapterOutRepository;
using ExemploHexagonal.AdapterOutRepository.postgreSql;
using ExemploHexagonal.Domain;

namespace ExemploHexagonal.App
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDomain();
            builder.Services.AddPersistence(configuration);

            builder.Services.AddRepository();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGenCustomized("Hexagonal example");

            builder.Services.ConfigureVersioning();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.AllowSwaggerToListApiVersions("Hexagonal example");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MigrateDatabase();

            app.Run();
        }
    }
}