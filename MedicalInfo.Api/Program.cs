using MedicalInfo.Api.Middlewares;
using MedicalInfo.App.Interfaces;
using MedicalInfo.App.Mappings;
using MedicalInfo.App.Services;
using MedicalInfo.Domain.Interfaces;
using MedicalInfo.Infrastructure;
using MedicalInfo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicalInfo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MsSqlDbContext>(
                opt => opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("MsSqlDbConnect")));

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PatientProfile>();
                cfg.AddProfile<DoctorProfile>();
            });


            builder.Services.AddTransient<IPatientService,PatientService>();
            builder.Services.AddTransient<IPatientRepository, PatientRepository>();

            builder.Services.AddTransient<IDoctorService, DoctorService>();
            builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionsHandler();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
