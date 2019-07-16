
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Objetivo : AudityEntity, ISoftDeleted
    {
        public int CodigoObjetivo { get; set; }
        public string NombreObjetivo { get; set; }

        public bool Deleted { get; set; }
    }
}
