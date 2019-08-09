using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Proyecto: AudityEntity, ISoftDeleted
    {
        public Proyecto()
        {
        }

        public Proyecto(string nombreProyecto, DateTime fechaAprobacion, DateTime fechaInicio, DateTime fechaFin, double montoProyecto, int beneficiarios)
        {
            NombreProyecto = nombreProyecto;
            FechaAprobacion = fechaAprobacion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            MontoProyecto = montoProyecto;
            Beneficiarios = beneficiarios;            
        }

        public string CodigoProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double MontoProyecto { get; set; }
        public int Beneficiarios { get; set; }
        
        public EstadoProyecto EstadoProyecto { get; set; }
        
        public int EstadoId { get; set; }

        public ICollection<ProyectoUsuario> ProyectoUsuarios { get; set; }

        public ICollection<ProyectoPais> ProyectoPaises { get; set; }

        public ICollection<ProyectoOrganizacion> ProyectoOrganizaciones { get; set; }

        public ICollection<ProyectoSocio> ProyectoSocios { get; set; }

        public ICollection<PlanMonitoreoEvaluacion> PlanMonitoreoEvaluaciones { get; set; }
        public bool Deleted { get; set; }

        public void AddIndicador(Indicador indicador)
        {
            PlanMonitoreoEvaluaciones.Add(new PlanMonitoreoEvaluacion(this, indicador));
        }

        public void AddPais(Pais pais)
        {
            ProyectoPaises.Add(new ProyectoPais(pais, this));
        }

        public void AddSocio(SocioInternacional socio)
        {
            ProyectoSocios.Add(new ProyectoSocio(socio, this));
        }

        public void AddOrganizacion(OrganizacionResponsable organizacion)
        {
            ProyectoOrganizaciones.Add(new ProyectoOrganizacion(organizacion, this));
        }
    }
}
