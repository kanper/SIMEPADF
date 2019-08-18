using System;

namespace DTO.DTO
{
    public class ActividadRtDTO
    {
        public int Id { get; set; }        
        public string NombreActividad { get; set; }
        public DateTime FechaLimite { get; set; }
        public double Monto { get; set; }
    }
}