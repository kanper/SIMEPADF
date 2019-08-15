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
        public int FuenteDatoId { get; set; }
        public string NombreFuenteDato { get; set; }
        public int FrecuenciaMedicionId { get; set; }
        public string NombreFrecuenciaMedicion { get; set; }
        public int NivelImpactoId { get; set; }
        public string NombreNivelImpacto { get; set; }
        public MapDTO[] Desagregaciones { get; set; }
    }
}