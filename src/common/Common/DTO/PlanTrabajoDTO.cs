using System;
using System.Linq;

namespace DTO.DTO
{
    public class PlanTrabajoDTO
    {
        public string Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ProyectoId { get; set; }
        public string NombreProyecto { get; set; }
        public double MontoOriginal { get; set; }
        private string fecha;
        public string Fecha
        {
            get
            {
                if (IsPlanTrabajo)
                    return FechaCreacion.ToString();
                else
                {
                    return "####-##-##";
                }
            }
            set => fecha = value;
        }
        private double montoRestante;
        public double MontoRestante
        {
        get { return AcumuladoActividad != null ? Math.Round(MontoOriginal - AcumuladoActividad.Sum(),2) : 0.0; }
        set => montoRestante = value;
        }

        public double[] AcumuladoActividad { get; set; }

        public bool IsPlanTrabajo { get; set; }
    }
}