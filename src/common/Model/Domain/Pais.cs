﻿using Model.Domain.DbHelper;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Pais: AudityEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string NombrePais { get; set; }
        public string SiglaPais { get; set; }

        public ICollection<ProyectoPais> ProyectoPaises { get; set; }

        public ICollection<ActividadPTPais> ActividadPTPaises { get; set; }

        public bool Deleted { get; set; }

        public void AddProyecto(Proyecto proyecto)
        {
            ProyectoPaises.Add(new ProyectoPais(this, proyecto));            
        }

        public void AddActividad(ActividadPT actividadPT)
        {
            ActividadPTPaises.Add(new ActividadPTPais(this, actividadPT));
        }
    }
}
