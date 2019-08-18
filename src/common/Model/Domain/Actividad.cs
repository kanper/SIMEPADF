using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Actividad : AudityEntity, ISoftDeleted
    {
        public Actividad()
        {
        }

        public Actividad(string nombreActividad, string nombreIndicador, int meta)
        {
            NombreActividad = nombreActividad;
            Indicador = new Indicador(nombreIndicador,meta);
        }
        
        public Actividad(string nombreActividad, string nombreIndicador, int meta, float porcentaje)
        {
            NombreActividad = nombreActividad;
            Indicador = new Indicador(nombreIndicador,meta, porcentaje);
        }

        public int CodigoActividad { get; set; }
        public string NombreActividad { get; set; }
        
        public Resultado Resultado { get; set; }
        public int ResultadoId { get; set; }

        public virtual Indicador Indicador { get; set; }       

        public bool Deleted { get; set; }
    }
}