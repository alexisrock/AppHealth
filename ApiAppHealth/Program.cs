using ApiAppHealth.Middlewares;
using Core.Integration;
using Core.Interface;
using Core.Service;
using DataAccess;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
        .AddJsonOptions(JsonOptions =>
                JsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
 {

     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api App Healt", Version = "v1" });
     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
     {
         Name = "Authorization",
         Type = SecuritySchemeType.Http,
         Scheme = "Bearer",
         BearerFormat = "JWT",
         In = ParameterLocation.Header,
         Description = "JWT Authorization header using the Bearer scheme",
     });

     c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }

    });
     var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
     c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
 });
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(typeof(CondicionHandler).GetTypeInfo().Assembly, typeof(SintomasHandler).GetTypeInfo().Assembly  );
});



builder.Services.AddDbContext<AppHealthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdEM"),
    sqlServerOptionsAction: options =>
    {
        options.EnableRetryOnFailure();
    });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IInfermedicaIntegration, InfermedicaIntegration>(); 
builder.Services.AddScoped(typeof(IDataAccess<>), typeof(DataAccess<>));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();

