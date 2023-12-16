using CharacterHistoryRole.Application;
using CharacterHistoryRole.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowOrigin",
        builder => builder.SetIsOriginAllowed(_ => true)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials()
    );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCharacterHistoryRoleApplicationExtension();

builder.Services.AddDbContext<CharacterHistoryRoleContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RoleCharacterSheet"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    //var _context = scope.ServiceProvider.GetRequiredService<CharacterHistoryRoleContext>();
    //_context.Database.Migrate();
}

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
