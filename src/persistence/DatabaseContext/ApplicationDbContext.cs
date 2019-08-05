using DatabaseContext.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Model.Domain.DbHelper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<UsuarioRol>().HasKey(sc => new { sc.UsuarioId, sc.RolId });
            builder.Entity<ProyectoOrganizacion>().HasKey(sc => new { sc.OrganizacionId, sc.ProyectoId });
            builder.Entity<ProyectoPais>().HasKey(sc => new { sc.PaisId, sc.ProyectoId });
            builder.Entity<ProyectoSocio>().HasKey(sc => new { sc.SocioId, sc.ProyectoId });
            builder.Entity<ProyectoUsuario>().HasKey(sc => new { sc.UsuarioId, sc.ProyectoId });

            AddMyFilters(ref builder);

            new UsuarioConfig(builder.Entity<Usuario>());
            new RolConfig(builder.Entity<Rol>());
            new EstadoProyectoConfig(builder.Entity<EstadoProyecto>());
            new OrganizacionConfig(builder.Entity<OrganizacionResponsable>());
            new PaisConfig(builder.Entity<Pais>());
            new ProyectoConfig(builder.Entity<Proyecto>());
            new SocioConfig(builder.Entity<SocioInternacional>());
            new ObjetivoConfig(builder.Entity<Objetivo>());
            new ResultadoConfig(builder.Entity<Resultado>());
            new ActividadConfig(builder.Entity<Actividad>());
            new IndicadorConfig(builder.Entity<Indicador>());
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        //public DbSet<UsuarioRol> UsuarioRol { get; set; }
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

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AudityEntity;

                if (entity != null)
                {
                    var date = DateTime.UtcNow;
                    //int personalId;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        //entity.CreatedBy = personalId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        //entity.DeletedBy = personalId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    //entity.UpdatedBy = personalId;
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
            modelBuilder.Entity<SocioInternacional>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<OrganizacionResponsable>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Pais>().HasQueryFilter(x => !x.Deleted);
            #endregion
        }
    }
}
