using System;

namespace DTO.DTO
{
    public class PlanTrabajoDTO
    {
        private string fecha;
        public string Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ProyectoId { get; set; }
        public string NombreProyecto { get; set; }

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

        public bool IsPlanTrabajo { get; set; }
    }
}