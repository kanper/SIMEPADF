using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Desagregacion : AudityEntity, ISoftDeleted
    {
        public Desagregacion()
        {
        }

        public Desagregacion(string tipoDesagregacion)
        {
            TipoDesagregacion = tipoDesagregacion;
        }

        public int Id { get; set; }
        public string TipoDesagregacion { get; set; }

        public ICollection<PlanDesagregacion> PlanDesagregaciones { get; set; }

        public bool Deleted { get; set; }
    }
}