using Data;
using Meetup_API.Extantions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ConnectionString
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
//Conection
builder.Services.AddDbContext<MeetupContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddRepositories();
builder.Services.AddServises();

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
