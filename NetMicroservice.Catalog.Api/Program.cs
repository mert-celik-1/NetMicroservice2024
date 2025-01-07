using NetMicroservice.Catalog.Api;
using NetMicroservice.Catalog.Api.Features.Categories;
using NetMicroservice.Catalog.Api.Features.Courses;
using NetMicroservice.Catalog.Api.Options;
using NetMicroservice.Catalog.Api.Repositories;
using NetMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();

builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

builder.Services.AddVersioningExt();


var app = builder.Build();

app.AddSeedDataExt().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data has been saved successfully");
});


app.AddCategoryGroupEndpointExt(app.AddVersionSetExt());
app.AddCourseGroupEndpointExt(app.AddVersionSetExt());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
