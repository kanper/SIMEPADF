namespace DTO.DTO
{
    public class SeguimientoIndicadorWrapperDTO
    {
        public int Id { get; set; }
        public int CodigoResultado { get; set; }
        public string NombreResultado { get; set; }
        public string NombreObjetivo { get; set; }
        public SeguimientoIndicadorDTO[] Indicadores { get; set; }
    }
}