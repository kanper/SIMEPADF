using DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Services;

namespace CoreApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();                   
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddDbContext<simepadfContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("TemporalDatabase"))
            );

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IOrganizacionResponsableService, OrganizacionResponsableService>();
            services.AddTransient<IPaisService, PaisService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<ISocioInternacionalService, SocioInternacionalService>();
            services.AddTransient<IObjetivoService, ObjetivoService>();
            services.AddTransient<IResultadoService, ResultadoService>();
            services.AddTransient<IActividadService, ActividadService>();
            services.AddTransient<IIndicadorService, IndicadorService>();
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<IProyectoHelperService, ProyectoHelperService>();
            services.AddTransient<IFuenteDatoService, FuenteDatoService>();
            services.AddTransient<IDesagregacionService, DesagregacionService>();
            services.AddTransient<INivelImpactoService, NivelImpactoService>();
            services.AddTransient<IPlanMonitoreoEvaluacionService, PlanMonitoreoEvaluacionService>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SIMEPADF API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();                     
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIMEPADF API V1");
            });           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {               
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);           
            app.UseMvc();
        }
    }
}
