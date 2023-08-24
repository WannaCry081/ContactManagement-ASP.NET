using System.Text;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using backend.Data;
using backend.Repositories.AuthRepository;
using backend.Repositories.ContactRepository;
using backend.Repositories.ContactLogRepository;
using backend.Repositories.UserRepository;
using backend.Repositories.UserLogRepository;
using backend.Services.AuthService;
using backend.Services.ContactService;
using backend.Services.ContactLogService;
using backend.Services.UserService;
using backend.Services.UserLogService;

var builder = WebApplication.CreateBuilder(args);

// Invoke the ConfigureServices method
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader();
});

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable authorization middleware
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();

// Configure services for dependency injection
void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // Configure database context using SQL Server
    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        );
    });

    // Configure AutoMapper
    services.AddAutoMapper(typeof(Program).Assembly);

    // Configure Cross-origin resource sharing
    services.AddCors();

    // Add HttpContextAccessor for accessing HttpContext in services
    services.AddHttpContextAccessor();

    // Register authentication and authorization services
    services.AddScoped<IAuthRepository, AuthRepository>();
    services.AddScoped<IAuthService, AuthService>();

    // Register contact repository and service
    services.AddScoped<IContactRepository, ContactRepository>();
    services.AddScoped<IContactService, ContactService>();
    
    services.AddScoped<IContactLogRepository, ContactLogRepository>();
    services.AddScoped<IContactLogService, ContactLogService>(); 

    // Register user repository and service
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserService, UserService>();

    services.AddScoped<IUserLogRepository, UserLogRepository>();
    services.AddScoped<IUserLogService, UserLogService>();

    // Configure Swagger API documentation
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        // Configure OAuth2 security definition for Swagger
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        // Apply security filter to operations
        options.OperationFilter<SecurityRequirementsOperationFilter>();

        // Configure Swagger documentation settings
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "Contact Management System API",
            Description = "A simple Contact Management System API showcasing basic CRUD operations.",
            Contact = new OpenApiContact()
            {
                Name = "Lirae Que A. Data",
                Url = new Uri("https://github.com/TheDayDreamer01")
            }
        });

        // Include XML comments for documentation
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

    // Configure JWT Bearer authentication
    services.AddAuthentication().AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("AppSettings:JWT_SECRET_KEY").Value!
                )
            )
        };
    });
}