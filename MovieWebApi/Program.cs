using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;
using MLRModel;
using MovieWebApi.Contracts.Dto.Mapping;
using MovieWebApi.Extensions;
using MovieWebApi.Infrastructure.Business.Authentication;
using MovieWebApi.Infrastructure.ML;
using MovieWebApi.Infrastructure.ML.DataModels;
using MovieWebApi.Services.Interfaces.Authentication;
using NLog;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.AddPredictionEnginePool<MovieRating, ModelOutput>()
    .FromFile(Path.Combine(Environment.CurrentDirectory, "MLRModel", "MovieRecommenderModel.zip"));
builder.Services.AddScoped<IMLRecommendation, MLRecommendation>();


builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Api", Version = "v1" });
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Place to add JWT with Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });
});
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerServices();
builder.Services.ConfigureDatabaseContext(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddHttpContextAccessor();

//ServiceExtensions.ConfigureDatabaseContext(builder.Services, builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
//builder.Services.ConfigureExceptionHandlerMiddleware();


var app = builder.Build();
//var logger = app.Services.GetRequiredService<ILoggerManager>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Api v1");
    });
}
else
{
    app.UseHsts();
}

//app.ConfigureExceptionHandler(logger);

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
