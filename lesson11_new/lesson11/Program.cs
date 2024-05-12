using DataAccess.DalApi;
using DataAccess.DalImplemintation;
using DataAccess.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using BL.blImplemintation;
using BL.blApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
DBActions db = new DBActions(builder.Configuration);
string connStr = db.GetConnectionString("Academy");
builder.Services.AddDbContext<AcademyContext>(opt => opt.UseSqlServer(connStr));
builder.Services.AddScoped<IUniversityRepo, UniversityRepo>();
builder.Services.AddScoped<IURYRepo, URYRepo>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();


app.Run();
