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

        public bool IsCancelled
        {
            get
            {
                return EstadoProyecto.Equals("CANCELADO", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool IsCompleted
        {
            get
            {
                return EstadoProyecto.Equals("FINALIZADO", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool IsIncomplete
        {
            get
            {
                return EstadoProyecto.Equals("INCOMPLETO", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool IsInProcess
        {
            get
            {
                return EstadoProyecto.Equals("EN PROCESO", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool IsVerified
        {
            get
            {
                return EstadoProyecto.Equals("VERIFICAR", StringComparison.OrdinalIgnoreCase);
            }
        }

    }
}