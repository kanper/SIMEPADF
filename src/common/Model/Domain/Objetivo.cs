﻿
using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Objetivo : AudityEntity, ISoftDeleted
    {
        public Objetivo()
        {
        }

        public Objetivo(string nombreObjetivo)
        {
            NombreObjetivo = nombreObjetivo;
        }

        public int CodigoObjetivo { get; set; }
        public string NombreObjetivo { get; set; }

        public ICollection<Resultado> Resultados { get; set; }

        public bool Deleted { get; set; }
    }
}
