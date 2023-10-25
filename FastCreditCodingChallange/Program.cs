using FastCreditCodingChallange.Utility;

namespace FastCreditCodingChallange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
            IConfiguration config = builder.Configuration;

            //builder.Services.AddDbContext<TimeSheetDbContext>();
            builder.Services.AddSingleton(config);

            ServiceExtension.RegisterServices(builder.Services, config, myAllowSpecificOrigins);

            // Add services to the container.

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

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}