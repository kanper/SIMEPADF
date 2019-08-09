using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class PlanMonitoreoEvaluacion : AudityEntity
    {
        public PlanMonitoreoEvaluacion()
        {
        }

        public PlanMonitoreoEvaluacion(Proyecto proyecto, Indicador indicador)
        {
            Proyecto = proyecto;
            Indicador = indicador;
        }

        public PlanMonitoreoEvaluacion(Proyecto proyecto, Indicador indicador, string metodologiaRecoleccion, string valorLineaBase)
        {
            Proyecto = proyecto;
            Indicador = indicador;
            MetodologiaRecoleccion = metodologiaRecoleccion;
            ValorLineaBase = valorLineaBase;
        }

        public Proyecto Proyecto { get; set; }
        public string ProyectoId { get; set; }

        public Indicador Indicador { get; set; }
        public int IndicadorId { get; set; }
        
        public string MetodologiaRecoleccion { get; set; }
        public string ValorLineaBase { get; set; }

        public FuenteDato FuenteDato { get; set; }
        public int FuenteDatoId { get; set; }

        public FrecuenciaMedicion FrecuenciaMedicion { get; set; }
        public int FrecuenciaMedicionId { get; set; }

        public NivelImpacto NivelImpacto { get; set; }
        public int NivelImpactoId { get; set; }

        public ICollection<PlanDesagregacion> PlanDesagregaciones { get; set; }

        public void AddDesagregacion(Desagregacion desagregacion)
        {
            PlanDesagregaciones.Add(new PlanDesagregacion(this, desagregacion));
            ;
        }
    }
}