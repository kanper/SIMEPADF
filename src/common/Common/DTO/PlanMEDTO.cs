namespace DTO.DTO
{
    public class PlanMEDTO
    {
        public string ProyectoId { get; set; }
        public int IndicadorId { get; set; }
        public string NombreProyecto { get; set; }
        public string NombreIndicador { get; set; }
        public string Metodologia { get; set; }
        public string LineaBase { get; set; }        
        public MapDTO FuenteDato { get; set; }
        public MapDTO FrecuenciaMedicion { get; set; }
        public MapDTO NivelImpacto { get; set; }
        public MapDTO[] Desagregaciones { get; set; }
    }
}