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
        public bool Completa { get; set; }
        public string PaisesF => DTOFormater.FormatArray(Paises);
        public string FechaInicioF => DTOFormater.FormatDate(FechaInicio);
        public string FechaFinF => DTOFormater.FormatDate(FechaFin);
        public string FechaLimiteF => DTOFormater.FormatDate(FechaLimite);
        public string IsCompleta => Completa ? "Completa" : "Incompleta";
    }
}