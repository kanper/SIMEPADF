using System.ComponentModel.DataAnnotations.Schema;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Indicador : AudityEntity, ISoftDeleted
    {
        public Indicador()
        {
        }

        public Indicador(string nombreIndicador, int meta)
        {
            NombreIndicador = nombreIndicador;
            Meta = new Meta(meta);
        }

        [ForeignKey("Actividad")]
        public int CodigoIndicador { get; set; }
        public string NombreIndicador { get; set; }
        
        public virtual Actividad Actividad { get; set; }

        public virtual Meta Meta { get; set; }

        public bool Deleted { get; set; }       
    }
}