using System;
using System.Linq;
using DatabaseContext;

namespace Services
{
    public interface IEntidadActualizableValidacionService
    {
        bool IsProductoActualizable(int id, string identifier);
        bool IsProyectoActualizable(string id, string identifier);
        bool IsActividadPTActualizable(int id, string identifier);
        bool IsObjetivoActualizable(int id, string identifier);
        bool IsResultadoActualizable(int id, string identifier);
        bool IsActividadActualizable(int id, string identifier);
        bool IsIndicadorActualizable(int id, string identifier);
        bool IsOrganizacionActualizable(int id, string identifier);
        bool IsSocioActualizable(int id, string identifier);
        bool IsPaisActualizable(int id, string identifier);
        bool IsFuenteActualizable(int id, string identifier);
        bool IsNivelActualizable(int id, string identifier);
        bool IsDesagregadoActualizable(int id, string identifier);
        bool IsUsuarioActualizable(string id, string identifier);
        
    }
    
    public class EntidadActualizableValidacionService : IEntidadActualizableValidacionService
    {
        private readonly simepadfContext _context;

        public EntidadActualizableValidacionService(simepadfContext context)
        {
            _context = context;
        }

        public bool IsProductoActualizable(int id, string identifier)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsProyectoActualizable(string id, string identifier)
        {
            try
            {
                return !_context.Proyecto.Any(p => p.NombreProyecto == identifier) || 
                       _context.Proyecto.Any(p => p.CodigoProyecto == id && p.NombreProyecto == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsActividadPTActualizable(int id, string identifier)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsObjetivoActualizable(int id, string identifier)
        {
            try
            {
                return !_context.Objetivo.Any(o => o.NombreObjetivo == identifier) || 
                       _context.Objetivo.Any(o => o.CodigoObjetivo == id && o.NombreObjetivo == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsResultadoActualizable(int id, string identifier)
        {
            try
            {
                return !_context.Resultado.Any(r => r.NombreResultado == identifier) || 
                       _context.Resultado.Any(r => r.CodigoResultado == id && r.NombreResultado == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsActividadActualizable(int id, string identifier)
        {
            try
            {
                return !_context.Actividad.Any(a => a.NombreActividad == identifier) || 
                       _context.Actividad.Any(a => a.CodigoActividad == id && a.NombreActividad == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsIndicadorActualizable(int id, string identifier)
        {
            try
            {
                return !_context.Indicador.Any(i=> i.NombreIndicador == identifier) || 
                       _context.Indicador.Any(i => i.CodigoIndicador == id && i.NombreIndicador == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsOrganizacionActualizable(int id, string identifier)
        {
            try
            {
                return !_context.OrganizacionResponsable.Any(o => o.NombreOrganizacion == identifier) || 
                       _context.OrganizacionResponsable.Any(o => o.Id == id && o.NombreOrganizacion == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsSocioActualizable(int id, string identifier)
        {
            try
            {
                return !_context.SocioInternacional.Any(s => s.NombreSocio == identifier) || 
                       _context.SocioInternacional.Any(s => s.Id == id && s.NombreSocio == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsPaisActualizable(int id, string identifier)
        {
            try
            {
                return !_context.Pais.Any(p => p.NombrePais == identifier) || 
                       _context.Pais.Any(p => p.Id == id && p.NombrePais == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsFuenteActualizable(int id, string identifier)
        {
            try
            {
                return !_context.FuenteDato.Any(f => f.NombreFuente == identifier) || 
                       _context.FuenteDato.Any(f => f.Id == id && f.NombreFuente == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsNivelActualizable(int id, string identifier)
        {
            try
            {
                return !_context.NivelImpacto.Any(n => n.NombreNivelImpacto == identifier) || 
                       _context.NivelImpacto.Any(n => n.Id == id && n.NombreNivelImpacto == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsDesagregadoActualizable(int id, string identifier)
        {
            try
            {
                return !_context.Desagregacion.Any(d => d.TipoDesagregacion == identifier) || 
                       _context.Desagregacion.Any(d => d.Id == id && d.TipoDesagregacion == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsUsuarioActualizable(string id, string identifier)
        {
            try
            {
                return !_context.Usuario.Any(u => u.Email == identifier) || 
                       _context.Usuario.Any(u => u.Id == id && u.Email == identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}