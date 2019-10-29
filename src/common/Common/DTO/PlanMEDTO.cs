namespace DTO.DTO
{
    public class PlanMEDTO
    {
        public string ProyectoId { get; set; }
        public int IndicadorId { get; set; }
        public string NombreProyecto { get; set; }
        public string NombreIndicador { get; set; }
        public int ActividadId { get; set; }
        public string NombreActividad { get; set; }
        public int ResultadoId { get; set; }
        public string NombreResultado { get; set; }
        public int ObjetivoId { get; set; }
        public string NombreObjetivo { get; set; }
        public string Metodologia { get; set; }
        public string LineaBase { get; set; }        
        public MapDTO FuenteDato { get; set; }
        public MapDTO FrecuenciaMedicion { get; set; }
        public MapDTO NivelImpacto { get; set; }
        public MapDTO[] Desagregaciones { get; set; }
    }
}