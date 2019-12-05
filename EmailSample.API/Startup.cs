using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Email.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            EmailSample.Domain.Model.AppConfiguration config = new EmailSample.Domain.Model.AppConfiguration();
            Configuration.Bind("AppConfiguration", config);
            services.AddSingleton(config);

            services.AddTransient<SmtpClient>((serviceProvider) =>
            {
                return new SmtpClient()
                {
                    Host = config.Email.Smtp.Host,
                    Port = config.Email.Smtp.Port,
                    Credentials = new NetworkCredential(config.Email.Smtp.Username, config.Email.Smtp.Password)
                };
            });
            services.AddTransient<EmailSample.Data.Context.DatabaseContext>();
            services.AddTransient<EmailSample.Domain.Services.IEmailServices, EmailSample.Domain.Services.EmailServices>();
            services.AddTransient<EmailSample.Data.Interfaces.IEmailRepo, EmailSample.Data.Repositories.EmailRepo> ();
            
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
