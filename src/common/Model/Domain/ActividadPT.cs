using System;
using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class ActividadPT : AudityEntity, ISoftDeleted
    {
        public ActividadPT()
        {
        }

        public ActividadPT(string nombreActividad, DateTime fechaInicio, DateTime fechaLimite, double monto)
        {
            NombreActividad = nombreActividad;
            FechaInicio = fechaInicio;
            FechaLimite = fechaLimite;
            Monto = monto;
        }

        public int CodigoActividadPT { get; set; }
        public string NombreActividad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public double Monto { get; set; }

        public PlanTrabajo PlanTrabajo { get; set; }
        public string PlanTrabajoCodigoPlanTrabajo { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public void AddProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public bool Deleted { get; set; }
    }
}