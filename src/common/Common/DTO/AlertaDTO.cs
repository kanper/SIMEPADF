using System;
using System.Reflection.Metadata.Ecma335;
using Model.Domain;

namespace DTO.DTO
{
    public class AlertaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public string Pais { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaNotificacion => DTOFormater.FormatDateTime(Fecha);
    }
}