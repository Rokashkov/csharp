using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace App
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");

            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var currentAssemblyName = typeof(AppDbContext).Assembly.FullName;

                options.UseNpgsql(
                    connectionString,
                    builder => builder.MigrationsAssembly(currentAssemblyName)
                );
            });

            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "App",
                    Description = "Итоговая работа на курсе \"Технологии программирования и алгоритмизации в медицине\"",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }

        public static void UseDevelopment(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }

        public static async void MigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (context == null)
            {
                throw new Exception("Cannot initialize the database context");
            }

            await context.Database.MigrateAsync();
        }
    }
}
