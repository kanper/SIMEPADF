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
        
        public string FechaCreacionF()
        {
            return DTOFormater.FormatDate(FechaCreacion);
        }

        public string FechaInicioF()
        {
            return DTOFormater.FormatDate(FechaInicio);
        }

        public string FechaLimiteF()
        {
            return DTOFormater.FormatDate(FechaLimite);
        }

        public string MontoF()
        {
            return DTOFormater.FormatMoney(Monto);
        }

        public string PaisesF()
        {
            return DTOFormater.FormatArray(Paises);
        }

        public string ProductosF()
        {
            return DTOFormater.FormatArray(Productos);
        }

    }
}