using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoP6_Enroll.Models;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();


        //add cadena de conexion
        var CnnStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CNNSTR"));

        CnnStrBuilder.Password = "progra6";


        string CnnStr = CnnStrBuilder.ConnectionString;

        builder.Services.AddDbContext<Proyectop62024Context>(options => options.UseSqlServer(CnnStr));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}