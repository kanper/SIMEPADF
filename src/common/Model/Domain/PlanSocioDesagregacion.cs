using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class PlanSocioDesagregacion
    {
        public PlanSocioDesagregacion()
        {
        }

        public PlanSocioDesagregacion(PlanDesagregacion planDesagregacion, SocioInternacional socioInternacional)
        {
            PlanDesagregacion = planDesagregacion;
            SocioInternacional = socioInternacional;
            Trimestre = QuarterCalculator.GetQuarter(DateTime.Now);
            Valor = 0;
            Fecha = DateTime.Now;
        }

        public double Valor { get; set; }
        public int Trimestre { get; set; }
        public string CodigoPais { get; set; }
        public DateTime Fecha { get; set; }
        public string PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto { get; set; }
        public int PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId { get; set; }
        public int PlanDesagregacionDesagregacionId { get; set; }
        public PlanDesagregacion PlanDesagregacion { get; set; }
        public SocioInternacional SocioInternacional { get; set; }
        [ForeignKey("SocioInternacional")]
        public int SocioInternacionalId { get; set; }
    }
}