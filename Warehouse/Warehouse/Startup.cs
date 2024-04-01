using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Warehouse.DatabaseConnector;
using Warehouse.Model;
using Warehouse.Repositories.ItemsRepo;
using Warehouse.Repositories.OrdersRepo;
using Warehouse.Services.AuthenticationService;
using Warehouse.Services.Items;
using Warehouse.Services.TokenService;

namespace Warehouse;
public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors();
        services.AddEndpointsApiExplorer();
        services.AddHttpContextAccessor();

        AddSwagger(services);

        AddAuthentication(services);
        AddIdentity(services);
        var connectionString = Configuration["ConnectionString"];
        services.AddDbContext<UserContext>(options => options.UseNpgsql(connectionString));
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IAuthService, AuthService>();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(o => o
            .SetIsOriginAllowed(origin => true)
            //.AllowCredentials()
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        AddRoles(app);
    }

    private void AddAuthentication(IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var validIssuer = config["Authentication:ValidIssuer"];
        var validAudience = config["Authentication:ValidAudience"];
        var claimNameSub = config["Authentication:ClaimNameSub"];
        var issuerSigningKey = Configuration["Authentication:IssuerSigningKey"];

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(issuerSigningKey)
                    )
                };
            });
    }

    private void AddIdentity(IServiceCollection services)
    {
        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<UserContext>();
    }

    private void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Warehouse",
                Version = "v1"
            });

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    }, new string[]{ }
                }
        });
        });
    }

    void AddRoles(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var tCoordinator = CreateRole(roleManager, "Coordinator");
        tCoordinator.Wait();

        var tEmployee = CreateRole(roleManager, "Employee");
        tEmployee.Wait();


    }

    private async Task CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
    {
        var adminRoleExists = await roleManager.RoleExistsAsync(roleName);
        if (!adminRoleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}




