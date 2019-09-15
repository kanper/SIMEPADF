using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DatabaseContext.Config;
using DTO.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Domain;
using Model.Domain.DbHelper;

namespace DatabaseContext
{
    public partial class simepadfContext : IdentityDbContext<Usuario>
    {
        private readonly ICurrentUserDTO _currentUser;

        public simepadfContext()
        {
            
        }

        public simepadfContext(DbContextOptions<simepadfContext> options, ICurrentUserDTO currentUser = null )
            : base(options)
        {
            _currentUser = currentUser;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=(localdb)\\padf;Database=SIMEPADF;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=simepadf;User ID=SA;Password=Sqlserver2017;Encrypt=false;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
            modelBuilder.Entity<ProyectoOrganizacion>().HasKey(sc => new { sc.OrganizacionResponsableId, sc.ProyectoId });
            modelBuilder.Entity<ProyectoPais>().HasKey(sc => new { sc.PaisId, sc.ProyectoId });
            modelBuilder.Entity<ProyectoSocio>().HasKey(sc => new { sc.SocioInternacionalId, sc.ProyectoId });
            modelBuilder.Entity<ProyectoUsuario>().HasKey(sc => new { sc.UsuarioId, sc.ProyectoId });
            modelBuilder.Entity<PlanMonitoreoEvaluacion>().HasKey(sc => new {sc.ProyectoCodigoProyecto, sc.IndicadorId});
            modelBuilder.Entity<PlanDesagregacion>().HasKey(sc => new 
                {sc.DesagregacionId, sc.PlanMonitoreoEvaluacionIndicadorId, sc.PlanMonitoreoEvaluacionProyectoCodigoProyecto});

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.UserId, p.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId});
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId });

            AddMyFilters(ref modelBuilder);

            new UsuarioConfig(modelBuilder.Entity<Usuario>());
            new RolConfig(modelBuilder.Entity<Rol>());
            new EstadoProyectoConfig(modelBuilder.Entity<EstadoProyecto>());
            new OrganizacionConfig(modelBuilder.Entity<OrganizacionResponsable>());
            new PaisConfig(modelBuilder.Entity<Pais>());
            new ProyectoConfig(modelBuilder.Entity<Proyecto>());
            new SocioConfig(modelBuilder.Entity<SocioInternacional>());
            new ObjetivoConfig(modelBuilder.Entity<Objetivo>());
            new ResultadoConfig(modelBuilder.Entity<Resultado>());
            new ActividadConfig(modelBuilder.Entity<Actividad>());
            new IndicadorConfig(modelBuilder.Entity<Indicador>());
            new MetaConfig(modelBuilder.Entity<Meta>());
            new PlanMonitoreoEvaluacionConfig(modelBuilder.Entity<PlanMonitoreoEvaluacion>());
            new FuenteDatoConfig(modelBuilder.Entity<FuenteDato>());
            new FrecuenciaMedicionConfig(modelBuilder.Entity<FrecuenciaMedicion>());
            new NivelImpactoConfig(modelBuilder.Entity<NivelImpacto>());
            new DesagregacionConfig(modelBuilder.Entity<Desagregacion>());
            new PlanTrabajoConfig(modelBuilder.Entity<PlanTrabajo>());
            new ActividadPtConfig(modelBuilder.Entity<ActividadPT>());
            new ProductoConfig(modelBuilder.Entity<Producto>());

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<SocioInternacional> SocioInternacional { get; set; }
        public DbSet<EstadoProyecto> EstadoProyecto { get; set; }
        public DbSet<OrganizacionResponsable> OrganizacionResponsable { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<ProyectoOrganizacion> ProyectoOrganizacion { get; set; }
        public DbSet<ProyectoPais> ProyectoPais { get; set; }
        public DbSet<ProyectoSocio> ProyectoSocio { get; set; }
        public DbSet<ProyectoUsuario> ProyectoUsuario { get; set; }
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<Indicador> Indicador { get; set; }
        public DbSet<Meta> Meta { get; set; }

        public DbSet<PlanMonitoreoEvaluacion> PlanMonitoreoEvaluacion { get; set; }

        public DbSet<FuenteDato> FuenteDato { get; set; }

        public DbSet<FrecuenciaMedicion> FrecuenciaMedicion { get; set; }

        public DbSet<NivelImpacto> NivelImpacto { get; set; }

        public DbSet<Desagregacion> Desagregacion { get; set; }

        public DbSet<PlanDesagregacion> PlanDesagregacion { get; set; }

        public DbSet<PlanTrabajo> PlanTrabajo { get; set; }

        public DbSet<ActividadPT> ActividadPT { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            MakeAudit();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            MakeAudit();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is AudityEntity
                     && (
                         x.State == EntityState.Added
                         || x.State == EntityState.Modified
                )
            );

            var user = new CurrentUser();

            if (_currentUser != null)
            {
                user = _currentUser.Get;
            }

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AudityEntity;

                if (entity != null)
                {
                    var date = DateTime.Now;
                    string userId = user.UserId;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }

        private void AddMyFilters(ref ModelBuilder modelBuilder)
        {
            #region SoftDeleted
            modelBuilder.Entity<Usuario>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Objetivo>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Resultado>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Actividad>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Indicador>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Proyecto>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Pais>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<OrganizacionResponsable>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<SocioInternacional>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<FuenteDato>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<NivelImpacto>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Desagregacion>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Meta>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<PlanTrabajo>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<ActividadPT>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Producto>().HasQueryFilter(x => !x.Deleted);
            #endregion
        }

    }
}
