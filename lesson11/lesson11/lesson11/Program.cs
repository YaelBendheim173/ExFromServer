using DataAccess.DalApi;
using DataAccess.DalImplemintation;
using DataAccess.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
DBActions db = new DBActions(builder.Configuration);
string connStr = db.GetConnectionString("Academy");
builder.Services.AddDbContext<AcademyContext>(opt => opt.UseSqlServer(connStr));
builder.Services.AddScoped<IUniversityRepo, UniversityRepo>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();


app.Run();
