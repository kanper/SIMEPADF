using System.ComponentModel.DataAnnotations.Schema;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Meta : AudityEntity, ISoftDeleted
    {
        public Meta() {}

        public Meta(double valorMeta)
        {
            ValorMeta = valorMeta;
        }

        [ForeignKey("Indicador")]
        public int CodigoMeta { get; set; }
        public double ValorMeta { get; set; }
        public bool Deleted { get; set; }
        public virtual Indicador Indicador { get; set; }
    }
}