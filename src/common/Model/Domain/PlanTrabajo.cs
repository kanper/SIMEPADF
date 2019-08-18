using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class PlanTrabajo : AudityEntity, ISoftDeleted
    {
        public PlanTrabajo()
        {
        }

        public PlanTrabajo(DateTime fechaCreacion)
        {
            FechaCreacion = fechaCreacion;
        }

        [ForeignKey("Proyecto")]
        public string CodigoPlanTrabajo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Proyecto Proyecto { get; set; }        

        public ICollection<ActividadPT> ActividadPTs { get; set; }
        public bool Deleted { get; set; }
    }
}