using System.ComponentModel.DataAnnotations.Schema;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Meta : AudityEntity, ISoftDeleted
    {
        public Meta()
        {
        }

        public Meta(int valorMeta)
        {
            ValorMeta = valorMeta;
        }

        public Meta(int valorMeta, float porcentaje)
        {
            ValorMeta = valorMeta;
            Porcentaje = porcentaje;
        }

        [ForeignKey("Indicador")]
        public int CodigoMeta { get; set; }
        public int ValorMeta { get; set; }
        public float Porcentaje { get; set; }
        public bool Deleted { get; set; }
       
        public virtual Indicador Indicador { get; set; }
    }
}