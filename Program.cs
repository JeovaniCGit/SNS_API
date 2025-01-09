
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SNS.Data;
using SNS.Services;

namespace SNS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();
            builder.Services.AddScoped<IBaixaMedicaService, BaixaMedicaService>();
            builder.Services.AddScoped<IMedicoService, MedicoService>();
            builder.Services.AddScoped<IPacienteService, PacienteService>();
            builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();



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
        }
    }
}
