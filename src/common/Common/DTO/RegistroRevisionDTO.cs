using System;

namespace DTO.DTO
{
    public class RegistroRevisionDTO
    {

        public bool Revisado { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public int Trimestre { get; set; }
        public string Pais { get; set; }
        public string Comentario { get; set; }
        public bool Retornado { get; set; }
        public string FechaF => DTOFormater.FormatDateTime(Fecha);
        public string TrimestreF => $"Q{Trimestre}";
        public string Rol => GetRolByReviewNumber(Numero);

        private string GetRolByReviewNumber(int reviewNumber)
        {
            switch (Numero)
            {
                case 1:
                    return "Director Financiero";
                case 2:
                    return "Director de País";
                case 3:
                    return "Monitoreo y Evaluación";
                default:
                    return "N/A";
            }
        }
    }
}