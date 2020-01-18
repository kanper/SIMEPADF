using System;

namespace DTO.DTO
{
    public class ProyectoDTO
    {       
        public string Id { get; set; }
        public string NombreProyecto { get; set; }
        public bool Regional { get; set; }
        public DateTime FechaAprobacion { get; set; }       
        public DateTime FechaInicio { get; set; }       
        public DateTime FechaFin { get; set; }       
        public double MontoProyecto { get; set; }
        public double Beneficiarios { get; set; }
        public double PorcentajeAvance { get; set; }
        public string TipoBeneficiario { get; set; }
        public string EstadoProyecto {get; set; }
        public bool IsPlanTrabajo { get; set; }
        public bool IsActividadPlanTrabajo { get; set; }
        public bool IsIndicador { get; set; }
        public MapDTO[] Paises { get; set; }
        public MapDTO[] Organizaciones { get; set; }
        public MapDTO[] Socios { get; set; }
        public PlanMEDTO[] Indicadores { get; set; }
        public ActividadPtDTO[] Planes { get; set; }
        public int TotalActividades { get; set; }
        public int TotalActividadesFinalizadas { get; set; }
        public bool IsChecked { get; set; }
        public bool IsApproved { get; set; }
        public string AvancePlanTrabajo
        {
            get
            {
                if (TotalActividades == 0)
                {
                    return DTOFormater.FormatPercent(0.0);
                }
                var percent = TotalActividadesFinalizadas / TotalActividades;
                return DTOFormater.FormatPercent(Convert.ToDouble(percent));
            }
        }

        public string AvanceBeneficiarios => DTOFormater.FormatPercent(PorcentajeAvance / Beneficiarios);
        public bool IsCancelled => EstadoProyecto.Equals("CANCELADO", StringComparison.OrdinalIgnoreCase);
        public bool IsCompleted => EstadoProyecto.Equals("FINALIZADO", StringComparison.OrdinalIgnoreCase);
        public bool IsIncomplete => EstadoProyecto.Equals("INCOMPLETO", StringComparison.OrdinalIgnoreCase);
        public bool IsInProcess => EstadoProyecto.Equals("EN_PROCESO", StringComparison.OrdinalIgnoreCase);
        public bool IsPreVerified => EstadoProyecto.Equals("PRE_VERIFICAR", StringComparison.OrdinalIgnoreCase);
        public bool IsVerified => EstadoProyecto.Equals("VERIFICAR", StringComparison.OrdinalIgnoreCase);
        public bool Is1Review => EstadoProyecto.Equals("1REVISION", StringComparison.OrdinalIgnoreCase);
        public bool Is2Review => EstadoProyecto.Equals("2REVISION", StringComparison.OrdinalIgnoreCase);
        public bool Is3Review => EstadoProyecto.Equals("3REVISION", StringComparison.OrdinalIgnoreCase);
        public string Clasificacion => Regional ? "Regional" : "Nacional";
        public string Estado => DTOFormater.FormatProjectStatus(EstadoProyecto);

    }
}