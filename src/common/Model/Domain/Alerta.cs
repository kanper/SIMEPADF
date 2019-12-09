using System;

namespace Model.Domain
{
    public class Alerta
    {
        public Alerta()
        {
        }

        public Alerta(string titulo, string mensaje, string tipo, string rol, string pais, string usuario)
        {
            Titulo = titulo;
            Mensaje = mensaje;
            Tipo = tipo;
            Rol = rol;
            Pais = pais;
            Usuario = usuario;
            Inicio = DateTime.Now;
            Expira = DateTime.Now.AddDays(30);
            Revisado = false;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public bool Revisado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Expira { get; set; }
        public string Rol { get; set; }
        public string Pais { get; set; }
        public string Usuario { get; set; }
    }
}