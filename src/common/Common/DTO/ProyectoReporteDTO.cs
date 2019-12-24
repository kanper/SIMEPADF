namespace DTO.DTO
{
    public class ProyectoReporteDTO
    {
        public string Id { get; set; }
        public string NombreProyecto { get; set; }
        public string Estado { get; set; }
        public bool Regional { get; set; }
        public string Objetivo { get; set; }
        public string Resultado { get; set; }
        public string Actividad { get; set; }
        public string Indicador { get; set; }
        public MapDTO[] Paises { get; set; } 
        public MapDTO[] Organizaciones { get; set; }
        public string EstadoProyecto => DTOFormater.FormatProjectStatus(Estado);
        public string Clasificacion => Regional ? "Regional" : "Nacional";
        public string ListaPaises => DTOFormater.FormatArray(Paises);
        public string ListaOrganizaciones => DTOFormater.FormatArray(Organizaciones);
        
    }
}