
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Model.Domain
{
    public class ProyectoPais
    {
        public ProyectoPais()
        {
        }

        public ProyectoPais(Pais pais, Proyecto proyecto)
        {
            Pais = pais;
            Proyecto = proyecto;
        }               

        public int PaisId { get; set; }
        public Pais Pais { get; set; }

        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }

        public ICollection<RegistroRevision> RegistroRevisiones { get; set; }

        public bool Equals(int pais, string proyecto)
        {
            return PaisId == pais && ProyectoId == proyecto;
        }

        public void AddProcesoRevision()
        {
            var fullMonthName = new DateTime().ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            for (var i = 1; i <= 3; i++)
            {
                RegistroRevisiones.Add(new RegistroRevision(i + "REVISION", fullMonthName));
            }
        }
    }
}
