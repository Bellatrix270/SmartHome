using SmartHome.Backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("http://192.168.0.107:3000")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});
builder.Services.AddRouting();

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.UseEndpoints(x =>
{
    x.MapHub<RoomHub>("/rooms-hub");
    x.MapControllers();
});

// Configure the HTTP request pipeline.
if (false)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();