
namespace Model.Domain
{
    public class ProyectoPais
    {
        public ProyectoPais()
        {
        }

        public ProyectoPais(Pais pais, Proyecto proyecto)
        {
            Pais = pais;
            Proyecto = proyecto;
        }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
