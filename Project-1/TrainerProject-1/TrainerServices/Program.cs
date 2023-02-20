using EntityLayer.Entities;
using EL = EntityLayer;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var trainer_config = builder.Configuration.GetConnectionString("TutorApp");
builder.Services.AddDbContext<TutorAppContext>(options => options.UseSqlServer( trainer_config) );
builder.Services.AddScoped<ILogic, Logic>();
builder.Services.AddScoped<EL.IEFRepo, EL.TrainerEFRepo>();
//var AllowPages = "Allowpages";
//builder.Services.AddCors(options =>
//options.AddPolicy(AllowPages, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); })) ;

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    
}));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
