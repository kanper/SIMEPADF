namespace DTO.DTO
{
    public class SeguimientoIndicadorTableDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int IdDesagregado { get; set; }
        public double Valor { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
    }
}