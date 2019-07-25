using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Resultado: AudityEntity, ISoftDeleted
    {
        public int CodigoResultado { get; set; }
        public string NombreResultado { get; set; }

        public Objetivo Objetivo { get; set; }
        public int ObjetivoId { get; set; }

        public ICollection<Actividad> Actividades { get; set; }

        public bool Deleted { get; set; }
    }
}