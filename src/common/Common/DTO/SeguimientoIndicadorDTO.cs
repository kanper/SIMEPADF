namespace DTO.DTO
{
    public class SeguimientoIndicadorDTO
    {
        public int Id { get; set; }
        public string NombreIndicador { get; set; }
        public string NombreActividad { get; set; }
        public string Nivel { get; set; }
        public string Frecuencia { get; set; }
        public string Metodologia { get; set; }
        public string Fuente { get; set; }
        public double Meta { get; set; }
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

    }
}