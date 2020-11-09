using ClassesTimetable.Core.Entities;
using ClassesTimetable.Core.Interfaces;
using ClassesTimetable.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassesTimetable.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //services.AddScoped<IRepository<ClassRoom>>(p => new Repository<ClassRoom>(p.GetRequiredService<DatabaseContext>()));
            //services.AddScoped<IRepository<TypeOfLesson>>(p => new Repository<TypeOfLesson>(p.GetRequiredService<DatabaseContext>()));
            //services.AddScoped<IRepository<TypeOfLessonLesson>>(p => new Repository<TypeOfLessonLesson>(p.GetRequiredService<DatabaseContext>()));

        }
    }
}
