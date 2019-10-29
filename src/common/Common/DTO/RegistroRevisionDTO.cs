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
    }
}