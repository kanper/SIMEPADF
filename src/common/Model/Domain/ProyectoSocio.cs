using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class ProyectoSocio
    {

        public int SocioId { get; set; }
        public SocioInternacional SocioInternacional { get; set; }

        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
