using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddSingleton(AutoMapperConfig.Initialize());
builder.Services.AddDbContext<MyNotesContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyNotesCS")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyNotes API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
