using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Services
{
    public interface IIndicadorService
    {
        IndicadorDTO Get(int id);
        IEnumerable<IndicadorDTO> GetAll();              
        bool Update(IndicadorDTO model, int id);
        bool Delete(int id);
    }
    
    public class IndicadorService : IIndicadorService
    {
        private readonly simepadfContext _context;

        public IndicadorService(simepadfContext context)
        {
            _context = context;
        }

        public IndicadorDTO Get(int id)
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado
                        on o equals r.Objetivo
                    join a in _context.Actividad
                        on r equals a.Resultado
                    join i in _context.Indicador
                        on a equals i.Actividad
                    join m in _context.Meta
                        on i equals m.Indicador
                    where i.CodigoIndicador == id
                    select new IndicadorDTO()
                    {
                        Id = i.CodigoIndicador,
                        CodigoObjetivo = o.CodigoObjetivo,
                        NombreObjetivo = o.NombreObjetivo,
                        CodigoResultado = r.CodigoResultado,
                        NombreResultado = r.NombreResultado,
                        CodigoActividad = a.CodigoActividad,
                        NombreActividad = a.NombreActividad,
                        NombreIndicador = i.NombreIndicador,
                        ValorMeta = m.ValorMeta,
                        PorcentajeMeta = m.Porcentaje
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<IndicadorDTO> GetAll()
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado
                        on o equals r.Objetivo
                    join a in _context.Actividad
                        on r equals a.Resultado
                    join i in _context.Indicador
                        on a equals i.Actividad
                    join m in _context.Meta
                        on i equals m.Indicador
                    select new IndicadorDTO()
                    {
                        Id = i.CodigoIndicador,
                        CodigoObjetivo = o.CodigoObjetivo,
                        NombreObjetivo = o.NombreObjetivo,
                        CodigoResultado = r.CodigoResultado,
                        NombreResultado = r.NombreResultado,
                        CodigoActividad = a.CodigoActividad,
                        NombreActividad = a.NombreActividad,
                        NombreIndicador = i.NombreIndicador,
                        ValorMeta = m.ValorMeta,
                        PorcentajeMeta = m.Porcentaje
                    }).ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<IndicadorDTO>();
            }
        }      

        public bool Update(IndicadorDTO model, int id)
        {
            try
            {
                var indicador = _context.Indicador.Include(m => m.Meta).Single(i => i.CodigoIndicador == id);
                indicador.NombreIndicador = model.NombreIndicador;
                indicador.Meta.ValorMeta = model.ValorMeta;
                indicador.Meta.Porcentaje = model.PorcentajeMeta;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var indicador = _context.Indicador.Include(m => m.Meta).Single(i => i.CodigoIndicador == id);
                indicador.NombreIndicador = "N/A";
                indicador.Meta.ValorMeta = 0;
                indicador.Meta.Porcentaje = 0;
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