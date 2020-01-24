using CoreApi.Config;
using DatabaseContext;
using DTO.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Model.Domain;
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
            services.AddIdentity<Usuario, Rol>(opts =>
            {
                opts.Password.RequireDigit = false;
                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<simepadfContext>()
                .AddDefaultTokenProviders();

            services.AddMyDependecies(Configuration);

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["Auth:Url"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = Configuration["Auth:ApiName"];
                });

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
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddDbContext<simepadfContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
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
            services.AddTransient<IPlanTrabajoService, PlanTrabajoService>();
            services.AddTransient<IActividadPtService, ActividadPtService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IProyectoInfoService, ProyectoInfoService>();
            services.AddTransient<ICurrentUserDTO, CurrentUserDTO>();
            services.AddTransient<IRegistroRevisionService, RegistroRevisionService>();
            services.AddTransient<ISimpleIdentificadorService, SimpleIdentificadorService>();
            services.AddTransient<IPlanTrabajoActividadService, PlanTrabajoActividadService>();
            services.AddTransient<IProductoEvidenciaService, ProductoEvidenciaService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IProyectoSeguimientoService, ProyectoSeguimientoService>();
            services.AddTransient<ISeguimientoIndicadorServer, SeguimientoIndicadorServer>();
            services.AddTransient<IAlertService, AlertService>();
            services.AddTransient<IAuditoriaService, AuditoriaService>();
            services.AddTransient<IProyectoReporteService, ProyectoReporteService>();
            services.AddTransient<IEntidadUnicaValidacionService, EntidadUnicaValidacionService>();
            services.AddTransient<IEntidadActualizableValidacionService, EntidadActualizableValidacionService>();
            services.AddTransient<IEntidadRemovibleValidacionService, EntidadRemovibleValidacionService>();
            services.AddTransient<IEntidadUtilizadaValidacionService, EntidadUtilizadaValidacionService>();
            services.AddTransient<IRegistroAprobacionService, RegistroAprobacionService>();
            
            // Email Service 
            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            
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
           
            app.UseAuthentication();
            //app.UseIdentity(); //This method is obsolete and will be removed in a future version
            app.UseAuthentication();
            app.UseCors(MyAllowSpecificOrigins);           
            app.UseMvc();
        }
    }
}
