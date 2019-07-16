using System.Collections.Generic;

namespace Model.Domain
{
    public class EstadoProyecto 
    {
        public int Id { get; set; }
        public string TipoEstado { get; set; }

        public ICollection<Proyecto> Proyecto { get; set; }
    }
}
