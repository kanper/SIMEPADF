using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class ProyectoSocio
    {
        public ProyectoSocio() {}
        public ProyectoSocio(SocioInternacional socioInternacional, Proyecto proyecto)
        {
            SocioInternacional = socioInternacional;
            Proyecto = proyecto;
        }
        public int SocioInternacionalId { get; set; }
        public SocioInternacional SocioInternacional { get; set; }
        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
