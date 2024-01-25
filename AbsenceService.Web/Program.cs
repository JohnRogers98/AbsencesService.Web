using AbsenceService.BLL.Services;
using AbsenceService.DAL.Repositories;
using AbsenceService.Web.Mapper;
using AbsencesService.Domain.Repositories;
using AbsencesService.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IEmployeesService, EmployeesService>();
builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();

builder.Services.AddTransient<IAbsencesService, AbsenceService.BLL.Services.AbsencesService>();
builder.Services.AddTransient<IAbsencesRepository, AbsencesRepository>();

var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.AddConsole();
});

builder.Services.AddAutoMapper(typeof(RequestsMappingProfile));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
