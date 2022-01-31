using eMedicalRecordsApp.Service;
using eMedicalRecordsApp.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPatientService>(new PatientService());
builder.Services.AddSingleton<IHealthRecordService>(new HealthRecordService());
builder.Services.AddSingleton<IDiagnosisService>(new DiagnosisService());
builder.Services.AddSingleton<IDoctorService>(new DoctorService());

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