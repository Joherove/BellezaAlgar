using BMVentaAPI.Venta;
using DMVentaAPI.Venta;
using DTDemoAPI.Mapper;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins"; //New
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDMVenta, DMVenta>();
builder.Services.AddScoped<IBMVenta, BMVenta>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
