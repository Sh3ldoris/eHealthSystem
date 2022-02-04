using System.Text;
using eMedicalRecordsApp.Security;
using eMedicalRecordsApp.Service;
using eMedicalRecordsApp.Service.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = "Issuer",
        ValidateAudience = true,
        ValidAudience = "Audience",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication")),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Add services to the container.
builder.Services.AddSingleton<IPatientService, PatientService>();
builder.Services.AddSingleton<IHealthRecordService, HealthRecordService>();
builder.Services.AddSingleton<IDiagnosisService, DiagnosisService>();
builder.Services.AddSingleton<IDoctorService, DoctorService>();
builder.Services.AddSingleton<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<JwtProcessor>();
app.MapControllers();

app.Run();