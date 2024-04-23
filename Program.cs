
using ITIDB_.net_WebApi.interfaces;
using ITIDB_.net_WebApi.Models;
using ITIDB_.net_WebApi.repositories;
using ITIDB_.net_WebApi.UniitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ITIDB_.net_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "ITI DB .net Web Api",
                    TermsOfService = new Uri("http://tempuri.org/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed Abdou",
                        Email = "modohoda2468@gmail.com"
                    },
                }
                );
                c.IncludeXmlComments("E:\\Elshfey-api\\ITIDB_.net_WebApi\\mydoc.xml");
                c.EnableAnnotations();
            });
            builder.Services.AddDbContext<ITIContext>(op=>op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("con")));

            builder.Services.AddCors(CorsOptions => {

                CorsOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
                {

                    CorsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });


            });

            //custom services

            //builder.Services.AddScoped<IStudentRepo, StudentRepository>();
            //builder.Services.AddScoped<IDepartmentRepo, DepartmentRepository>();

            //builder.Services.AddScoped<GenericRepository<Student>>();
            //builder.Services.AddScoped<GenericRepository<Department>>();

            builder.Services.AddScoped<UnitWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
           
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
