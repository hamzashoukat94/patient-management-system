using Application.ApplicationLayer.Patients;
using Application.Infrastructure.Data;
using FluentValidation;
using System.Reflection;

namespace Application.ApplicationLayer
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            return services;
        }
    }
}
