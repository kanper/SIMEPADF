using Model.Domain.DbHelper;
using System.Collections.Generic;

namespace Model.Domain
{
    public class SocioInternacional : AudityEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string NombreSocio { get; set; }
        public string SiglasSocio { get; set; }

        public ICollection<ProyectoSocio> ProyectoSocios { get; set; }

        public bool Deleted { get; set; }

        public void AddProyecto(Proyecto proyecto)
        {
            ProyectoSocios.Add(new ProyectoSocio(this, proyecto));
        }
    }
}
