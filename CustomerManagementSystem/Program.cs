
using CustomerManagementSystem.BL;
using CustomerManagementSystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CustomerManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(optiions =>
            {
                optiions.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            #region Adding Context
            builder.Services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerManagementSystem")));
            #endregion
            #region Adding_Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            #endregion
            #region Registering
            //-----
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUserManager, UserManager>();
            //-----
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<ICustomerManager, CustomerManager>();
            //-----
            builder.Services.AddScoped<ICustomerUserRepo, CustomerUserRepo>();
            builder.Services.AddScoped<ICustomerUserManager, CustomerUserManager>();
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
            #region Authentication
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "default";
                option.DefaultChallengeScheme = "default";

            }).AddJwtBearer("default", option =>
            {
                string keyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                var keyInBytes = Encoding.ASCII.GetBytes(keyString);
                var key = new SymmetricSecurityKey(keyInBytes);

                option.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}