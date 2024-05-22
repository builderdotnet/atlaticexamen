using AtlanticCity.BibliotecarioJC.Api.Extensions;
using AtlanticCity.BibliotecarioJC.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddAtlantic();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseCors("FRONT_END");
//app.UseAuthorization();

app.MapControllers();

app.Run();