using Gerson.Livro.Application.Services;
using Gerson.Livro.Data.Dapper.Connection;
using Gerson.Livro.Data.Dapper.Repositories;
using Gerson.Livro.Domain.Data;
using Gerson.Livro.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace Gerson.Livro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(options =>
           {
               options.AddPolicy("AllowSpecificOrigin",
                       item => item.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials());
           })
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureDI(services);
            ConfigureSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app
                .UseSwagger()
                .UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint($"/swagger/v1/swagger.json", "Gerson API v1.0");
                });
        }

        public void ConfigureDI(IServiceCollection services)
        {
            services.AddTransient<ILivroService, LivroService>();
            services.AddTransient<IGeneroService, GeneroService>();
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<IEditoraService, EditoraService>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddSingleton<GersonConnectionFactory>();
        }

        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetAssembly(typeof(Startup)).Location, "xml"));
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Gerson API",
                    Version = "V1.0",
                    Description = "Api do Gerson"
                });
            });
        }
    }
}
