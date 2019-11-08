using System;

namespace DTO.DTO
{
    public class ActividadPtDTO
    {
        public int Id { get; set; }
        public string NombreProyecto { get; set; }
        public string NombreActividad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public double Monto { get; set; }
        public MapDTO[] Paises { get; set; }
        public MapDTO[] Productos { get; set; }
        public string FechaCreacionF => DTOFormater.FormatDate(FechaCreacion);
        public string FechaInicioF => DTOFormater.FormatDate(FechaInicio);
        public string FechaLimiteF => DTOFormater.FormatDate(FechaLimite);
        public string MontoF => DTOFormater.FormatMoney(Monto);
        public string PaisesF => DTOFormater.FormatArray(Paises);
        public string ProductosF => DTOFormater.FormatArray(Productos);
    }
}