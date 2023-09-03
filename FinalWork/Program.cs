using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using App.Services;
using App.Mappers;
using App.Middlewares;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            builder.Services.RegisterDatabase(configuration);
            builder.Services.RegisterSwagger();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IRoleService, RoleService>();
            builder.Services.AddTransient<IUserOnRoleService, UserOnRoleService>();
            builder.Services.AddTransient<IPostService, PostService>();
            builder.Services.AddTransient<ICommentService, CommentService>();
            builder.Services.AddAutoMapper(typeof(AppProfile));

            var app = builder.Build();

            app.MigrateDatabase();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseDevelopment();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}