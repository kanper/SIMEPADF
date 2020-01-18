using System;

namespace DTO.DTO
{
    public class RegistroAprobadoDTO
    {
        public string CodigoProyecto { get; set; }
        public int CodigoPais { get; set; }
        public string NombrePais { get; set; }
        public DateTime Fecha { get; set; }
        public bool Aprobado { get; set; }
        public string FechaF => DTOFormater.FormatDateTime(Fecha);
    }
}