using MovieWebApi.Contracts.Dto.Mapping;
using MovieWebApi.Extensions;
using System.Configuration;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureDatabaseContext(builder.Configuration);

//ServiceExtensions.ConfigureDatabaseContext(builder.Services, builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
//builder.Services.ConfigureExceptionHandlerMiddleware();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthorization();

//app.MapControllers();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
