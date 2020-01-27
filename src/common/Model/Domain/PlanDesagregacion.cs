using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.Domain
{
    public class PlanDesagregacion
    {
        public PlanDesagregacion() {}
        public PlanDesagregacion(PlanMonitoreoEvaluacion planMonitoreoEvaluacion, Desagregacion desagregacion)
        {
            PlanMonitoreoEvaluacion = planMonitoreoEvaluacion;
            Desagregacion = desagregacion;
        }
        public PlanMonitoreoEvaluacion PlanMonitoreoEvaluacion { get; set; }
        public string PlanMonitoreoEvaluacionProyectoCodigoProyecto { get; set; }
        public int PlanMonitoreoEvaluacionIndicadorId { get; set; }
        public int DesagregacionId { get; set; }
        public Desagregacion Desagregacion { get; set; }
        public ICollection<PlanSocioDesagregacion> PlanSocios { get; set; }
        public void AddPlanSocio(SocioInternacional socio)
        {
            PlanSocios.Add(new PlanSocioDesagregacion(this, socio));
        }

        public void AddPlanSocio(SocioInternacional socio, int Quarter)
        {
            PlanSocios.Add(new PlanSocioDesagregacion() {
                PlanDesagregacion = this, 
                SocioInternacional = socio,
                Trimestre = Quarter,
                Valor = 0,
                Fecha = DateTime.Now,
                Locked = false
            });
        }
    }
}