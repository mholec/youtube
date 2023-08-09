using System.Collections.Frozen;
using System.IO.Compression;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(x =>
{
    x.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});


var app = builder.Build();

app.MapGet("/", () =>
{
    List<Product> products = new();
    for (int i = 1; i <= 100; i++)
    {
        products.Add(new Product(){ProductNo = $"Product č. {i}", Price = i});
    }

    FrozenSet<Product> product2 = products.Where(x => x.Price > 80).ToFrozenSet();
    FrozenDictionary<string, decimal> product3 = products.Where(x => x.Price > 80)
        .ToFrozenDictionary(x => x.ProductNo, x => x.Price);
    
    return Results.Ok(product2);
});

app.Run();



public class Product
{
    public string ProductNo { get; set; }
    public decimal Price { get; set; }
}