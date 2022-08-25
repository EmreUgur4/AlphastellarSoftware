using EmreUgur.BackedProject.Business.Containers.MicrosoftIOC;
using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.Common.Models;
using EmreUgur.BackedProject.WebApi;
using EmreUgur.BackedProject.WebApi.CustomFilters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("global", cors =>
    {
        cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EmreUgur.BackendProject.WebApi",
        Version = "v1",
        Description = "EmreUgur BackendProject Api Document",
        Contact = new OpenApiContact
        {
            Email = "emreugur@heroda.com",
            Name = "Emre Uður"
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Description = "Bearer {token}"
    });
});

builder.Services.Configure<TokenInfo>(builder.Configuration.GetSection("TokenInfo"));

var tokenInfo = builder.Configuration.GetSection("TokenInfo").Get<TokenInfo>();

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(ValidId<>));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = true;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = tokenInfo.Issuer,
        ValidAudience = tokenInfo.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenInfo.SecurityKey)),
        ValidateIssuerSigningKey = false,
        ValidateLifetime = false,
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmreUgur.BackedProject.WebApi v1"));
}

app.UseExceptionHandler("/api/Error");

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("global");

using (var scope = app.Services.CreateScope())
{
    Initializer.SeedData(scope.ServiceProvider.GetRequiredService<IAppUserService>(), scope.ServiceProvider.GetRequiredService<IAppRoleService>(), scope.ServiceProvider.GetRequiredService<IAppUserRoleService>()).Wait();

    Initializer.SeedData2(scope.ServiceProvider.GetRequiredService<IColorService>(), scope.ServiceProvider.GetRequiredService<IVehicleService>(), scope.ServiceProvider.GetRequiredService<IWheelService>(), scope.ServiceProvider.GetRequiredService<IHeadlightService>(), scope.ServiceProvider.GetRequiredService<ICarService>(), scope.ServiceProvider.GetRequiredService<IBusService>(), scope.ServiceProvider.GetRequiredService<IBoatService>()).Wait();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
