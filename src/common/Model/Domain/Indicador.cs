using System.ComponentModel.DataAnnotations.Schema;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Indicador : AudityEntity, ISoftDeleted
    {
        [ForeignKey("Actividad")]
        public int CodigoIndicador { get; set; }
        public string NombreIndicador { get; set; }
        
        public virtual Actividad Actividad { get; set; }       

        public bool Deleted { get; set; }
    }
}