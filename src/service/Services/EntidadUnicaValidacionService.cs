using System;
using System.Linq;
using DatabaseContext;
using Microsoft.EntityFrameworkCore.Internal;

namespace Services
{
    public interface IEntidadUnicaValidacionService
    {
        bool IsActividadUnico(string identificador);
        bool IsObjetivoUnico(string identificador);
        bool IsResultadoUnico(string identificador);
        bool IsIndicadorUnico(string identificador);
        bool IsOrganizacionUnico(string identificador);
        bool IsSocioUnico(string identificador);
        bool IsPaisUnico(string identificador);
        bool IsFuenteUnico(string identificador);
        bool IsNivelUnico(string identificador);
        bool IsDesagregadoUnico(string identificador);
        bool IsProyectoUnico(string identificador);
        bool IsPlanPTUnico(string identificador);
        bool IsUsuarioUnico(string identificador);
    }
    
    public class EntidadUnicaValidacionService : IEntidadUnicaValidacionService
    {

        private readonly simepadfContext _context;

        public EntidadUnicaValidacionService(simepadfContext context)
        {
            _context = context;
        }

        public bool IsActividadUnico(string identificador)
        {
            try
            { 
                return !_context.Actividad.Any(a => a.NombreActividad == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsObjetivoUnico(string identificador)
        {
            try
            {
                return !_context.Objetivo.Any(o => o.NombreObjetivo == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsResultadoUnico(string identificador)
        {
            try
            {
                return !_context.Resultado.Any(r => r.NombreResultado == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsIndicadorUnico(string identificador)
        {
            try
            {
                return !_context.Indicador.Any(i => i.NombreIndicador == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsOrganizacionUnico(string identificador)
        {
            try
            {
                return !_context.OrganizacionResponsable.Any(o => o.NombreOrganizacion == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsSocioUnico(string identificador)
        {
            try
            {
                return !_context.SocioInternacional.Any(s => s.NombreSocio == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsPaisUnico(string identificador)
        {
            try
            {
                return !_context.Pais.Any(p => p.NombrePais == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsFuenteUnico(string identificador)
        {
            try
            {
                return !_context.FuenteDato.Any(f => f.NombreFuente == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsNivelUnico(string identificador)
        {
            try
            {
                return !_context.NivelImpacto.Any(n => n.NombreNivelImpacto == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsDesagregadoUnico(string identificador)
        {
            try
            {
                return !_context.Desagregacion.Any(d => d.TipoDesagregacion == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsProyectoUnico(string identificador)
        {
            try
            {
                return !_context.Proyecto.Any(p => p.NombreProyecto == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsPlanPTUnico(string identificador)
        {
            try
            {
                return !_context.ActividadPT.Any(a => a.NombreActividad == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsUsuarioUnico(string identificador)
        {
            try
            {
                return !_context.Usuario.Any(u => u.Email == identificador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}