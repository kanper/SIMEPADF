using System;

namespace DTO.DTO
{
    public class PlanTrabajoActividadDTO
    {
        public int Id { get; set; } //ActividadPT Id
        public string CodigoProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string NombreActividad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaLimite { get; set; }
        public MapDTO[] Paises { get; set; }
    }
}