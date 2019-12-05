using System;

namespace Model.Domain
{
    public class Alerta
    {
        public Alerta()
        {
        }

        public Alerta(string mensaje, string tipo, string rol, string pais)
        {
            Mensaje = mensaje;
            Tipo = tipo;
            Rol = rol;
            Pais = pais;
            Inicio = new DateTime();
            Expira = new DateTime().AddDays(30);
            Revisado = false;
        }

        public int Id { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public bool Revisado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Expira { get; set; }
        public string Rol { get; set; }
        public string Pais { get; set; }
    }
}