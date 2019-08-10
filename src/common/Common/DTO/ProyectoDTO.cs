using System;

namespace DTO.DTO
{
    public class ProyectoDTO
    {       
        public string Id { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaAprobacion { get; set; }       
        public DateTime FechaInicio { get; set; }       
        public DateTime FechaFin { get; set; }       
        public double MontoProyecto { get; set; }
        public int Beneficiarios { get; set; }
        public string EstadoProyecto { get; set; }
        public MapDTO[] Paises { get; set; }
        public MapDTO[] Organizaciones { get; set; }
        public MapDTO[] Socios { get; set; }

    }
}