using System;
using System.Globalization;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace Services
{
    public interface IEntidadRemovibleValidacionService
    {
        EntidadRemovibleDTO OrganizacionRemovible(int id);
        EntidadRemovibleDTO SocioRemovible(int id);
        EntidadRemovibleDTO PaisRemovible(int id);
        EntidadRemovibleDTO FuenteRemovible(int id);
        EntidadRemovibleDTO NivelRemovible(int id);
        EntidadRemovibleDTO DesagregadoRemovible(int id);
        EntidadRemovibleDTO ObjetivoRemovible(int id);
        EntidadRemovibleDTO ResultadoRemovible(int id);
        EntidadRemovibleDTO ActividadRemovible(int id);
        EntidadRemovibleDTO IndicadorRemovible(int id);
        EntidadRemovibleDTO ProductoRemovible(int id);
        EntidadRemovibleDTO ProyectoRemovible(string id);
        EntidadRemovibleDTO ActividadPTRemovible(int id);
        EntidadRemovibleDTO UsuarioRemovible(string id);
    }
    
    public class EntidadRemovibleValidacionService : IEntidadRemovibleValidacionService
    {
        private readonly simepadfContext _context;

        public EntidadRemovibleValidacionService(simepadfContext context)
        {
            _context = context;
        }

        public EntidadRemovibleDTO OrganizacionRemovible(int id)
        {
            try
            {
                return (from o in _context.OrganizacionResponsable
                    where o.Id == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = o.Id,
                        Identificador = o.NombreOrganizacion,
                        Removible = !(from po in _context.ProyectoOrganizacion
                                where po.OrganizacionResponsableId == id
                                      select po).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO SocioRemovible(int id)
        {
            try
            {
                return (from s in _context.SocioInternacional
                    where s.Id == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = s.Id,
                        Identificador = s.NombreSocio,
                        Removible = !(from ps in _context.ProyectoSocio
                                where ps.SocioInternacionalId == id
                                      select ps).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO PaisRemovible(int id)
        {
            try
            {
                return (from p in _context.Pais
                    where p.Id == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = p.Id,
                        Identificador = p.NombrePais,
                        Removible = !(from pp in _context.ProyectoPais
                                where pp.PaisId == id
                                      select pp).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO FuenteRemovible(int id)
        {
            try
            {
                return (from f in _context.FuenteDato
                    where f.Id == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = f.Id,
                        Identificador = f.NombreFuente,
                        Removible = !(from plan in _context.PlanMonitoreoEvaluacion
                                where plan.FuenteDatoId == id
                                      select plan).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO NivelRemovible(int id)
        {
            try
            {
                return (from n in _context.NivelImpacto
                    where n.Id == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = n.Id,
                        Identificador = n.NombreNivelImpacto,
                        Removible = !(from plan in _context.PlanMonitoreoEvaluacion
                                where plan.NivelImpactoId == id
                                      select plan).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO DesagregadoRemovible(int id)
        {
            try
            {
                return (from d in _context.Desagregacion
                    where d.Id == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = d.Id,
                        Identificador = d.TipoDesagregacion,
                        Removible = !(from plan in _context.PlanDesagregacion
                                where plan.DesagregacionId == id
                                      select plan).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO ObjetivoRemovible(int id)
        {
            try
            {
                return (from o in _context.Objetivo
                    where o.CodigoObjetivo == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = o.CodigoObjetivo,
                        Identificador = o.NombreObjetivo,
                        Removible = !(from r in _context.Resultado
                                where r.ObjetivoId == id
                                      select r).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO ResultadoRemovible(int id)
        {
            try
            {
                return (from r in _context.Resultado
                    where r.CodigoResultado == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = r.CodigoResultado,
                        Identificador = r.NombreResultado,
                        Removible = !(from a in _context.Actividad
                                where a.ResultadoId == id
                                      select a).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO ActividadRemovible(int id)
        {
            try
            {
                return (from a in _context.Actividad
                    where a.CodigoActividad == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = a.CodigoActividad,
                        Identificador = a.NombreActividad,
                        Removible = !(from p in _context.PlanMonitoreoEvaluacion
                                where p.IndicadorId == id
                                      select p).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO IndicadorRemovible(int id)
        {
            try
            {
                return (from i in _context.Indicador
                    where i.CodigoIndicador == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = i.CodigoIndicador,
                        Identificador = i.NombreIndicador,
                        Removible = !(from p in _context.PlanMonitoreoEvaluacion
                                where p.IndicadorId == id
                                      select p).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO ProductoRemovible(int id)
        {
            try
            {
                return (from p in _context.Producto
                    where p.codigoProducto == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = p.codigoProducto,
                        Identificador = p.NombreProducto,
                        Removible = !(from a in _context.ArchivoDescripcion
                                where a.CodigoArchivo == id
                                      select a).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO ProyectoRemovible(string id)
        {
            try
            {
                return (from p in _context.Proyecto
                    where p.CodigoProyecto == id
                    select new EntidadRemovibleDTO()
                    {
                        Codigo = p.CodigoProyecto,
                        Identificador = p.NombreProyecto,
                        Removible = true
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO ActividadPTRemovible(int id)
        {
            try
            {
                return (from a in _context.ActividadPT
                    where a.CodigoActividadPT == id
                    select new EntidadRemovibleDTO()
                    {
                        Id = a.CodigoActividadPT,
                        Identificador = a.NombreActividad,
                        Removible = !(from p in _context.Producto
                                where p.ActividadPTId == id
                                      select p).Any()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public EntidadRemovibleDTO UsuarioRemovible(string id)
        {
            try
            {
                return (from u in _context.Usuario
                    where u.Id == id
                    select new EntidadRemovibleDTO()
                    {
                        Codigo = u.Id,
                        Identificador = u.NombrePersonal + " " + u.ApellidoPersonal,
                        Removible = true
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    } 
}