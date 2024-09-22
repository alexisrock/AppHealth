using Core.Service;
using DataAccess;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api AdventureWorks2019", Version = "v1" });
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
    cfg.RegisterServicesFromAssemblies(typeof(PersonaAdressHandler).GetTypeInfo().Assembly, typeof(PersonAdressCreateHandler).GetTypeInfo().Assembly);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped(typeof(IDataAccess<>), typeof(DataAccess<>));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
 

app.MapControllers();

app.Run();

