namespace DTO.DTO
{
    public class ProyectoReporteDTO
    {
        public string Id { get; set; }
        public string NombreProyecto { get; set; }
        public string Estado { get; set; }
        public string EstadoProyecto => DTOFormater.FormatProjectStatus(Estado);
    }
}