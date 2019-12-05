namespace DTO.DTO
{
    public class SeguimientoIndicadorDTO
    {
        public int Id { get; set; }
        public string NombreIndicador { get; set; }
        public string NombreActividad { get; set; }
        public MapDTO[] OrganizacionesResponsables { get; set; }
        public MapDTO[] Desagregados { get; set; }
        public SeguimientoIndicadorTableDTO[] RegistroPaises { get; set; }
        public SeguimientoIndicadorTableDTO[] RegistroSocios { get; set; }
        public double Total { get; set; }
        public string ListaOrganizaciones => DTOFormater.FormatArray(OrganizacionesResponsables);
        
    }
}