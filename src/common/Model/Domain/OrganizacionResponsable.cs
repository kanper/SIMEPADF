using Model.Domain.DbHelper;
using System.Collections.Generic;

namespace Model.Domain
{
    public class OrganizacionResponsable: AudityEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string NombreOrganizacion { get; set; }
        public string SiglasOrganizacion { get; set; }

        public ICollection<ProyectoOrganizacion> ProyectoOrganizaciones { get; set; }

        public bool Deleted { get; set; }

        public void AddProyecto(Proyecto proyecto)
        {
            ProyectoOrganizaciones.Add(new ProyectoOrganizacion(this, proyecto));
        }
    }
}
