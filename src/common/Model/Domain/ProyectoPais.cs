﻿
using System;
using System.Collections.Generic;
using System.Globalization;
using Model.Domain.DbHelper;

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
            for (var i = 1; i <= 3; i++)
            {
                RegistroRevisiones.Add(new RegistroRevision(i , QuarterCalculator.GetQuarter(new DateTime())));
            }
        }
    }
}
