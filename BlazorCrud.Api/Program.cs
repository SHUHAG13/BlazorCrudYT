
using BlazorCrud.Api.Data;
using BlazorCrud.Api.Interface;
using BlazorCrud.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorCrud.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<AppDbContext>(Options =>
			Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddScoped<IStudentRepository, StudentRepository>();

			builder.Services.AddCors(options => options.AddPolicy("BlazorYTPolicy", policyBuilder =>
			{
				policyBuilder.WithOrigins("https://localhost:7109");
				policyBuilder.AllowAnyHeader();
				policyBuilder.AllowAnyMethod();


            }));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors("BlazorYTPolicy");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
