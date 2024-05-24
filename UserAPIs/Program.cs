
using Microsoft.EntityFrameworkCore;
using UserAPIs.Data;

namespace UserAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            var defaultConnection = $"Data Source={dbHost}; Database={dbName}; user=; password={dbPass}; Integrated Security=true;TrustServerCertificate=True";
            builder.Services.AddDbContext<UserDbContext>(option => option.UseSqlServer(defaultConnection));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
