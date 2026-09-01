using Microsoft.EntityFrameworkCore;
using UKPayroll.DataLayer;
using UKPayroll.DataLayer.Interfaces;
using UKPayroll.DataLayer.Repo;

namespace UKPayroll.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);   //Creates the WebApplicationBuilder factory class

                        // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();
          
        


            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            var app = builder.Build();  // builds the webApplication object from the builder and returns it to the app variable

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

           

                app.UseSwagger();  //Swagger documentation
                app.UseSwaggerUI();  //Swagger browser interface
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
