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

builder.Services.AddControllers();

// Configure database context using SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString);
});

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add HttpContextAccessor for accessing HttpContext in services
builder.Services.AddHttpContextAccessor();

// Register authentication and authorization services
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Register contact repository and service
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddScoped<IContactLogRepository, ContactLogRepository>();
builder.Services.AddScoped<IContactLogService, ContactLogService>();

// Register user repository and service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserLogRepository, UserLogRepository>();
builder.Services.AddScoped<IUserLogService, UserLogService>();

// Configure Swagger API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
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
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

// Configure JWT Bearer authentication
builder.Services.AddAuthentication().AddJwtBearer(options =>
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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Initialize();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable UseCors() 
app.UseCors();

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable authorization middleware
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();
