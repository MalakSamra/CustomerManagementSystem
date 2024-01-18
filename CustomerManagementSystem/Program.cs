
using CustomerManagementSystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CustomerManagementSystem
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
            #region Adding Context
            builder.Services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerManagementSystem")));
            #endregion
            #region Identity
            //Adding regolations to the identity table
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
                //Password
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                //User
                option.User.RequireUniqueEmail = true;
                //Max number of attempts
                option.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<UserContext>();
            #endregion
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