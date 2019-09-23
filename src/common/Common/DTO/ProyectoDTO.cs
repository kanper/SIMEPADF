using System;

namespace DTO.DTO
{
    public class ProyectoDTO
    {       
        public string Id { get; set; }
        public string NombreProyecto { get; set; }
        public bool Regional { get; set; }
        public DateTime FechaAprobacion { get; set; }       
        public DateTime FechaInicio { get; set; }       
        public DateTime FechaFin { get; set; }       
        public double MontoProyecto { get; set; }
        public int Beneficiarios { get; set; }
        public string EstadoProyecto {get; set; }
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

        public string Clasificacion
        {
            get
            {
                return Regional ? "Regional" : "Nacional";
            }
        }

        public string Estado
        {
            get
            {
                switch (EstadoProyecto)
                {
                    case "INCOMPLETO":
                        return "Datos Incompleto";
                    case "EN_PROCESO":
                        return "Proyecto en proceso";
                    case "CANCELADO":
                        return "Proyecto Cancelado";
                    case "FINALIZADO":
                        return "Proyecto Finalizado";
                    case "VERIFICAR":
                        return "Pendiente de verificación";
                    case "1REVISION":
                        return "Primera revisión";
                    case "2REVISION":
                        return "Segunda revisión";
                    case "3REVISION":
                        return "Tercera revisión";
                    default:
                        return "N/A";
                }
            }
        }

    }
}