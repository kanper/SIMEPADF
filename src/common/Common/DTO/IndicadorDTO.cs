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
        public double ValorMeta { get; set; }
        public string TipoBeneficiario { get; set; }
        public string ValorMetaF => TipoBeneficiario.Equals("N")
            ? DTOFormater.FormatNumber(ValorMeta)
            : DTOFormater.FormatPercent(ValorMeta);
    }
}