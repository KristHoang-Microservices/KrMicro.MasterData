using KrMicro.MasterData.Infrastructure;
using KrMicro.MasterData.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DbSQL");
builder.Services.AddDbContext<MasterDataDbContext>(opt => opt.UseSqlServer(connectionString),
    ServiceLifetime.Transient);

builder.Services.AddScoped<ICategoryService, CategoryRepositoryService>();
builder.Services.AddScoped<IBrandService, BrandRepositoryService>();
builder.Services.AddScoped<IProductService, ProductRepositoryService>();
builder.Services.AddScoped<IAscService, AscRepositoryService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllOrigins",
        policy => { policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod(); });
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