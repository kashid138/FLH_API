var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("File/Upload", (HttpRequest req) =>
{
if (!req.Form.Files.Any())
    return Results.BadRequest("Select one");
    foreach (var file in req.Form.Files)
    {
        using (var stream = new FileStream(@"C:\Users\Y0345731\Projects\File\" + file.FileName, FileMode.Create))
        {
            file.CopyTo(stream);
        }
    }
    return Results.Ok("Success");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
