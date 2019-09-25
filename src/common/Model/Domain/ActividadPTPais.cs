using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class ActividadPTPais
    {

        public ActividadPTPais()
        {
        }

        public ActividadPTPais(Pais pais, ActividadPT actividadPT)
        {
            Pais = pais;
            ActividadPT = actividadPT;
        }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public int ActividadPTCodigoActividadPT { get; set; }
        public ActividadPT ActividadPT { get; set; }

    }
}
