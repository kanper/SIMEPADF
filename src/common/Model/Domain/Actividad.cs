using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Actividad : AudityEntity, ISoftDeleted
    {
        public int CodigoActividad { get; set; }
        public string NombreActividad { get; set; }
        
        public Resultado Resultado { get; set; }
        public int ResultadoId { get; set; }

        public virtual Indicador Indicador { get; set; }       

        public bool Deleted { get; set; }
    }
}