using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Model.Domain;

namespace Services
{

    public interface IPlanMonitoreoEvaluacionService
    {
        PlanMEDTO Get(string proyectoId, int indicadorId);
        IEnumerable<PlanMEDTO> GetAll(string proyectoId);
        bool Add(IndicadorDTO[] model, string proyectoId);
        bool Update(PlanMEDTO model);
        bool Delete(string proyectoId, int indicadorId);
    }
    
    public class PlanMonitoreoEvaluacionService : IPlanMonitoreoEvaluacionService
    {
        private readonly simepadfContext _context;

        public PlanMonitoreoEvaluacionService(simepadfContext context)
        {
            _context = context;
        }

        public PlanMEDTO Get(string proyectoId, int indicadorId)
        {
            try
            {                
                return (from p in _context.Proyecto
                    join pme in _context.PlanMonitoreoEvaluacion
                        on p equals pme.Proyecto
                    join i in _context.Indicador
                        on pme.Indicador equals i
                    join fd in _context.FuenteDato
                        on pme.FuenteDato equals fd into Fuente
                    from PlanFuente in Fuente.DefaultIfEmpty()
                    join fm in _context.FrecuenciaMedicion
                        on pme.FrecuenciaMedicion equals fm into Frecuencia
                    from PlanFrecuencia in Frecuencia.DefaultIfEmpty()
                    join ni in _context.NivelImpacto
                        on pme.NivelImpacto equals ni into Nivel
                    from PlanNivel in Nivel.DefaultIfEmpty()
                    where p.CodigoProyecto == proyectoId && i.CodigoIndicador == indicadorId
                    select new PlanMEDTO()
                    {
                        ProyectoId = p.CodigoProyecto,
                        IndicadorId = i.CodigoIndicador,
                        NombreProyecto = p.NombreProyecto,
                        NombreIndicador = i.NombreIndicador,
                        LineaBase = pme.ValorLineaBase,
                        Metodologia = pme.MetodologiaRecoleccion,
                        FuenteDato = new MapDTO()
                        {
                            Id = PlanFuente == null ? 0 : PlanFuente.Id,
                            Nombre = PlanFuente == null ? string.Empty : PlanFuente.NombreFuente
                        },
                        FrecuenciaMedicion = new MapDTO()
                        {
                            Id = PlanFrecuencia == null ? 0 : PlanFrecuencia.Id,
                            Nombre = PlanFrecuencia == null ? string.Empty : PlanFrecuencia.NombreFrecuencia
                        },
                        NivelImpacto = new MapDTO()
                        {
                            Id = PlanNivel == null ? 0 : PlanNivel.Id,
                            Nombre = PlanNivel == null ? string.Empty : PlanNivel.NombreNivelImpacto
                        },                      
                        Desagregaciones = (
                            from pd in _context.PlanDesagregacion
                            join d in _context.Desagregacion
                                on pd.Desagregacion equals d
                            where pd.PlanMonitoreoEvaluacionProyectoCodigoProyecto == p.CodigoProyecto && pd.PlanMonitoreoEvaluacionIndicadorId == i.CodigoIndicador
                            select new MapDTO()
                            {
                                Id = d.Id,
                                Nombre = d.TipoDesagregacion
                            }).ToArray()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<PlanMEDTO> GetAll(string proyectoId)
        {
            try
            {
                return (from p in _context.Proyecto
                    join pme in _context.PlanMonitoreoEvaluacion
                        on p equals pme.Proyecto
                    join i in _context.Indicador
                        on pme.Indicador equals i                    
                    where p.CodigoProyecto == proyectoId
                    select new PlanMEDTO()
                    {
                        ProyectoId = p.CodigoProyecto,
                        IndicadorId = i.CodigoIndicador,
                        NombreProyecto = p.NombreProyecto,
                        NombreIndicador = i.NombreIndicador,
                        LineaBase = pme.ValorLineaBase,
                        Metodologia = pme.MetodologiaRecoleccion,                                                                      
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<PlanMEDTO>();
            }
        }

        public bool Add(IndicadorDTO[] model, string proyectoId)
        {
            try
            {
                var proyecto = _context.Proyecto.Include(p => p.PlanMonitoreoEvaluaciones).Single(p => p.CodigoProyecto == proyectoId);
                foreach (var dto in model)
                {
                    proyecto.AddIndicador(_context.Indicador.Single(i => i.CodigoIndicador == dto.Id));
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(PlanMEDTO model)
        {
            try
            {
                var socios = (from s in _context.SocioInternacional
                        join ps in _context.ProyectoSocio on s equals ps.SocioInternacional
                        where  ps.ProyectoId == model.ProyectoId
                        select s).ToList();
                var plan = _context.PlanMonitoreoEvaluacion
                    .Include(f => f.FuenteDato)
                    .Include(f => f.FrecuenciaMedicion)
                    .Include(n => n.NivelImpacto)
                    .Include(d => d.PlanDesagregaciones)
                    .Single(p => p.IndicadorId == model.IndicadorId && p.ProyectoCodigoProyecto == model.ProyectoId);
                plan.MetodologiaRecoleccion = model.Metodologia;
                plan.ValorLineaBase = model.LineaBase;
                plan.FuenteDato = _context.FuenteDato.Single(f => f.Id == model.FuenteDato.Id);
                plan.FrecuenciaMedicion = _context.FrecuenciaMedicion.Single(f => f.Id == model.FrecuenciaMedicion.Id);
                plan.NivelImpacto = _context.NivelImpacto.Single(n => n.Id == model.NivelImpacto.Id);
                
                foreach (var desagregado in plan.PlanDesagregaciones)
                {
                    desagregado.PlanSocios = _context.PlanSocioDesagregacion
                        .Where(p =>
                            p.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == model.ProyectoId &&
                            p.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == model.IndicadorId).ToList();
                    foreach (var planSocio in desagregado.PlanSocios)
                    {
                        _context.PlanSocioDesagregacion.Remove(planSocio);
                    }
                    desagregado.PlanSocios.Clear();
                    _context.SaveChanges();
                }
                
                foreach (var planDes in plan.PlanDesagregaciones)
                {
                    _context.PlanDesagregacion.Remove(planDes);
                }
                plan.PlanDesagregaciones.Clear();
                _context.SaveChanges();
                

                foreach (var dto in model.Desagregaciones)
                {
                    plan.AddDesagregacion(_context.Desagregacion.Single(d => d.Id == dto.Id));
                    _context.SaveChanges();
                }
                
                foreach (var des in plan.PlanDesagregaciones)
                {
                    des.PlanSocios = _context.PlanSocioDesagregacion
                        .Where(p =>
                            p.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == model.ProyectoId &&
                            p.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == model.IndicadorId).ToList();
                    foreach (var socio in socios)
                    {    
                        des.AddPlanSocio(socio);
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(string proyectoId, int indicadorId)
        {
            try
            {
                var plan = _context.PlanMonitoreoEvaluacion.Single(p =>
                    p.IndicadorId == indicadorId && p.ProyectoCodigoProyecto == proyectoId);
                _context.PlanMonitoreoEvaluacion.Remove(plan);
                _context.SaveChanges();
                return true;                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}