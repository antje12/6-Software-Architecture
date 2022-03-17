using System;
using System.IO;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlDocFile = Path.Combine(AppContext.BaseDirectory, "TA6_API.xml");
    if (File.Exists(xmlDocFile))
    {
        var comments = new XPathDocument(xmlDocFile);
        options.IncludeXmlComments(xmlDocFile);
        options.OperationFilter<XmlCommentsOperationFilter>(comments);
        options.SchemaFilter<XmlCommentsSchemaFilter>(comments);;
    }
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TA6 Weather API",
        Description = "An ASP.NET Core Web API for getting a location's weather",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

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
