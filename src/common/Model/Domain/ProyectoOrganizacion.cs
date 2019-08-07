
namespace Model.Domain
{
    public class ProyectoOrganizacion
    {
        public ProyectoOrganizacion()
        {
        }

        public ProyectoOrganizacion(OrganizacionResponsable organizacionResponsable, Proyecto proyecto)
        {
            OrganizacionResponsable = organizacionResponsable;
            Proyecto = proyecto;
        }

        public int OrganizacionId { get; set; }
        public OrganizacionResponsable OrganizacionResponsable { get; set; }

        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
