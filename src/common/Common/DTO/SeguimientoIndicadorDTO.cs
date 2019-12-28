namespace DTO.DTO
{
    public class SeguimientoIndicadorDTO
    {
        public int Id { get; set; }
        public int CodigoActividad { get; set; }
        public string NombreIndicador { get; set; }
        public string NombreActividad { get; set; }
        public string[] Niveles { get; set; }
        public string[] Frecuencias { get; set; }
        public string[] Metodologias { get; set; }
        public string[] Fuentes { get; set; }
        public double Meta { get; set; }
        public double MetaAnual { get; set; }
        public double TotalAnterior { get; set; }
        public double TotalQ1 { get; set; }
        public double TotalQ2 { get; set; }
        public double TotalQ3 { get; set; }
        public double TotalQ4 { get; set; }
        public MapDTO[] OrganizacionesResponsables { get; set; }
        public MapDTO[] Desagregados { get; set; }
        public SeguimientoIndicadorTableDTO[] RegistroSocios { get; set; }
        public string ListaOrganizaciones => DTOFormater.FormatArray(OrganizacionesResponsables);
        public string ListaDesagregados => DTOFormater.FormatArray(Desagregados);
        public double TotalAnio => TotalQ1 + TotalQ2 + TotalQ3 + TotalQ4;
        public string AvanceMetaAnual => DTOFormater.FormatPercent(TotalAnio / Meta);

    }
}