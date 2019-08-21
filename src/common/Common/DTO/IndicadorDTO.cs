namespace DTO.DTO
{
    public class IndicadorDTO
    {
        public int Id { get; set; }
        public int CodigoObjetivo { get; set; }
        public string NombreObjetivo { get; set; }
        public int CodigoResultado { get; set; }
        public string NombreResultado { get; set; }
        public int CodigoActividad { get; set; }
        public string NombreActividad { get; set; }       
        public string NombreIndicador { get; set; }
        public int ValorMeta { get; set; }

        private string meta;

        public string Meta
        {
            get
            {
                if (ValorMeta > 0)
                {
                    return ValorMeta.ToString();
                }
                else
                {
                    return PorcentajeMeta.ToString() + " %";
                }
            }
            set => meta = value;
        }

        public float PorcentajeMeta { get; set; }
    }
}