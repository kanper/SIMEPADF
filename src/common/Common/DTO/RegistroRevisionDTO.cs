using System;

namespace DTO.DTO
{
    public class RegistroRevisionDTO
    {
        public bool Revisado { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public string Trimestre { get; set; }
        public string Pais { get; set; }
    }
}