
namespace Model.Domain
{
    public class ProyectoPais
    {

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
