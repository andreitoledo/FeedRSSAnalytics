
using Altsystems.FeedRSSAnalytics.Infra.Data.Orm;
using Microsoft.EntityFrameworkCore;

namespace Altsystems.FeedRSSBlogsAnalyticsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // configuração para acessar o banco SQL
            ConfigurationManager configuration = builder.Configuration;
                        
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}