
using FleetManagement_MW.Models;
using FleetManagement_MW.Models.Repository;
using FleetManagement_MW.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers().AddNewtonsoftJson();

            builder.Services.AddTransient<IStateMasterRepository, SQLStateMasterRepository>();
            builder.Services.AddTransient<ICustomerMasterRepository, SQLCustomerMasterRepository>();
            builder.Services.AddTransient<ICarTypeMasterRepository, SQLCarTypeMasterRepository>();
            builder.Services.AddTransient<ICarMasterRepository, SQLCarMasterRepository>();
            builder.Services.AddTransient<IHubMasterInterface, SQLHubMasterRepository>();
            builder.Services.AddTransient<IAddOnMasterInterface, SQLAddOnMasterRepository>();
            builder.Services.AddTransient<ICityMasterInterface, SQLCityMasterRepository>();
            builder.Services.AddTransient<IAirportMasterInterface, SQLAirportMasterRepository>();
            builder.Services.AddTransient<IBookingDetailsInterface, SQLBookingDetailsRepository>();
            builder.Services.AddTransient<IBookingHeaderReservationInterface, SQLBookingHeaderReservationRepository>();
            builder.Services.AddTransient<IInvoiceHeaderTableHandoverService, SQLInvoiceHeaderTableHandoverRepository>();
            builder.Services.AddTransient<IInvoiceDetailTableReturnService, SQLInvoiceDetailTableReturnRepository>();



            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("fleetDBconnection")));


            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowedSpecificOrigin", builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

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

            app.UseCors("MyAllowedSpecificOrigin");

            app.Run();
        }
    }
}