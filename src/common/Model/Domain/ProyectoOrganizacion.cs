
namespace Model.Domain
{
    public class ProyectoOrganizacion
    {

        public int OrganizacionId { get; set; }
        public OrganizacionResponsable OrganizacionResponsable { get; set; }

        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
