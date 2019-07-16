using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Proyecto: AudityEntity, ISoftDeleted
    {
        public string CodigoProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public float MontoProyecto { get; set; }

        public ICollection<ProyectoUsuario> ProyectoUsuarios { get; set; }

        public ICollection<ProyectoPais> ProyectoPaises { get; set; }

        public ICollection<ProyectoOrganizacion> ProyectoOrganizaciones { get; set; }

        public ICollection<ProyectoSocio> ProyectoSocios { get; set; }

        public int EstadoId { get; set; }
        public EstadoProyecto EstadoProyecto { get; set; }

        public bool Deleted { get; set; }
    }
}
