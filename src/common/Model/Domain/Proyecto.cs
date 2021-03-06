﻿using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Proyecto: AudityEntity, ISoftDeleted
    {
        public Proyecto()
        {
        }

        public Proyecto(string nombreProyecto, bool regional, DateTime fechaAprobacion, DateTime fechaInicio, DateTime fechaFin, double montoProyecto, double beneficiarios)
        {
            NombreProyecto = nombreProyecto;
            Regional = regional;
            FechaAprobacion = fechaAprobacion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            MontoProyecto = montoProyecto;
            Beneficiarios = beneficiarios;
            TipoBeneficiario = "N";
        }

        public string CodigoProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public bool Regional { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double MontoProyecto { get; set; }
        public double Beneficiarios { get; set; }
        public double PorcentajeAvence { get; set; }
        public string TipoBeneficiario { get; set; }
        public EstadoProyecto EstadoProyecto { get; set; }
        public int EstadoProyectoId { get; set; }
        public ICollection<ProyectoUsuario> ProyectoUsuarios { get; set; }
        public ICollection<ProyectoPais> ProyectoPaises { get; set; }
        public ICollection<ProyectoOrganizacion> ProyectoOrganizaciones { get; set; }
        public ICollection<ProyectoSocio> ProyectoSocios { get; set; }
        public ICollection<PlanMonitoreoEvaluacion> PlanMonitoreoEvaluaciones { get; set; }
        public PlanTrabajo PlanTrabajo { get; set; }
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
        public void AddPlanTrabajo()
        {
            var plan = new PlanTrabajo();
            plan.FechaCreacion = DateTime.Now;
            plan.Proyecto = this;
        }
        public void RemovePais(ProyectoPais pais)
        {
            ProyectoPaises.Remove(pais);
        }
        public void RemoveSocio(ProyectoSocio socio)
        {
            ProyectoSocios.Remove(socio);
        }
        public void RemoveOrganizacion(ProyectoOrganizacion org)
        {
            ProyectoOrganizaciones.Remove(org);
        }
    }
}
