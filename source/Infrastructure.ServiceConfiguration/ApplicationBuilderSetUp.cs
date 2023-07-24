using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.ServiceConfiguration
{
	public static class ApplicationBuilderSetUp
	{
        public static void AddApplicationBuilder(this WebApplication? app)
        {
            if (app == null)
            {
                throw new ArgumentException(nameof(app));
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

