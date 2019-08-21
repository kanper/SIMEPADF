using System;

namespace DTO.DTO
{
    public class ActividadPtDTO
    {
        public int Id { get; set; }

        public string NombreProyecto { get; set; }
        public string NombreActividad { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public double Monto { get; set; }
    }
}