var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x =>
{
    x.AddPolicy("AllowForum", policy =>
    {
        //policy.AllowAnyOrigin();
        policy.WithOrigins("https://localhost:7159");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// if (app.Environment.IsDevelopment())
// {
//     app.Use(async (context, next) =>
//     {
//         context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
//         await next();
//     });
// }

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers().RequireCors(policy =>
{
    //policy.AllowAnyOrigin();
    policy.WithOrigins("https://localhost:7159");
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

// app.MapGet("/", () => "Hello World!").RequireCors();

app.Run();