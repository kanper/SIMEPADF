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

        public int ActividadPTId { get; set; }
        public ActividadPT ActividadPT { get; set; }

    }
}
