using System;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IProyectoInformationService
    {
        ProyectoDTO Get(string id);
    }
    
    public class ProyectoInformationService : IProyectoInformationService
    {
        private readonly simepadfContext _context;

        public ProyectoInformationService(simepadfContext context)
        {
            _context = context;
        }

        public ProyectoDTO Get(string id)
        {
            try
            {
                return (from p in _context.Proyecto
                    join e in _context.EstadoProyecto
                        on p.EstadoProyecto equals e
                        where p.CodigoProyecto == id
                    select new ProyectoDTO()
                    {
                        Id = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        Regional = p.Regional,
                        MontoProyecto = p.MontoProyecto,
                        FechaAprobacion = p.FechaAprobacion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        Beneficiarios = p.Beneficiarios,
                        TipoBeneficiario = p.TipoBeneficiario,
                        EstadoProyecto = e.TipoEstado,
                        Paises = (from pais in _context.Pais 
                            join pp in _context.ProyectoPais 
                                on pais equals pp.Pais 
                            where pp.ProyectoId == p.CodigoProyecto 
                            select new MapDTO()
                            {
                                Id = pais.Id, 
                                Nombre = pais.NombrePais
                            }).ToArray(),
                        Socios = (from socio in _context.SocioInternacional
                            join ps in _context.ProyectoSocio
                                on socio equals ps.SocioInternacional
                            where ps.ProyectoId == p.CodigoProyecto
                            select new MapDTO()
                                {
                                  Id = socio.Id,
                                  Nombre = socio.NombreSocio
                                }).ToArray(),
                        Organizaciones = (from org in _context.OrganizacionResponsable
                            join po in _context.ProyectoOrganizacion
                                on org equals po.OrganizacionResponsable
                            where po.ProyectoId == p.CodigoProyecto
                              select new MapDTO()
                              {
                                  Id = org.Id,
                                  Nombre = org.NombreOrganizacion
                              }).ToArray(),
                        Indicadores = (from pme in _context.PlanMonitoreoEvaluacion
                            join indicador in _context.Indicador 
                                on pme.Indicador equals indicador
                            join actividad in _context.Actividad 
                                on indicador.Actividad equals actividad
                            join resultado in _context.Resultado 
                                on actividad.Resultado equals resultado
                            join objetivo in _context.Objetivo 
                                on resultado.Objetivo equals objetivo 
                            where pme.ProyectoCodigoProyecto == id
                                  select new PlanMEDTO()
                                  {
                                      IndicadorId = indicador.CodigoIndicador,
                                      NombreIndicador = indicador.NombreIndicador,
                                      ActividadId = actividad.CodigoActividad,
                                      NombreActividad = actividad.NombreActividad,
                                      ResultadoId = resultado.CodigoResultado,
                                      NombreResultado = resultado.NombreResultado,
                                      ObjetivoId = objetivo.CodigoObjetivo,
                                      NombreObjetivo = objetivo.NombreObjetivo,
                                      Metodologia = pme.MetodologiaRecoleccion,
                                      LineaBase =  pme.ValorLineaBase,
                                      NivelImpacto = (from nivel in _context.NivelImpacto 
                                          where nivel == pme.NivelImpacto 
                                          select new MapDTO {Id = nivel.Id, Nombre = nivel.NombreNivelImpacto}).SingleOrDefault(),
                                      FuenteDato = (from fuente in _context.FuenteDato 
                                          where fuente == pme.FuenteDato 
                                          select new MapDTO {Id = fuente.Id, Nombre = fuente.NombreFuente}).SingleOrDefault(),
                                      FrecuenciaMedicion = (from frecuencia in _context.FrecuenciaMedicion 
                                          where frecuencia == pme.FrecuenciaMedicion 
                                          select new MapDTO {Id = frecuencia.Id, Nombre = frecuencia.NombreFrecuencia}).SingleOrDefault(),
                                      Desagregaciones = (from pds in _context.PlanDesagregacion
                                          join desg in _context.Desagregacion on pds.Desagregacion  equals desg
                                          where pds.PlanMonitoreoEvaluacionProyectoCodigoProyecto == id
                                            select new MapDTO
                                            {
                                                Id = desg.Id,
                                                Nombre = desg.TipoDesagregacion
                                            }).ToArray()
                                  }).ToArray(),
                        Planes = (from plan in _context.PlanTrabajo
                            join apt in _context.ActividadPT on plan equals apt.PlanTrabajo
                            where plan.CodigoPlanTrabajo == id
                                  select new ActividadPtDTO()
                                  {
                                      Id = apt.CodigoActividadPT,
                                      Monto = apt.Monto,
                                      NombreActividad = apt.NombreActividad,
                                      FechaCreacion = plan.FechaCreacion,
                                      FechaInicio = apt.FechaInicio,
                                      FechaLimite = apt.FechaLimite,
                                      Completa = apt.Completa,
                                      Paises = (from aps in _context.ActividadPTPais 
                                          join pais in _context.Pais on aps.Pais equals pais
                                          where aps.ActividadPTCodigoActividadPT == apt.CodigoActividadPT
                                                select new MapDTO()
                                                {
                                                    Id = pais.Id,
                                                    Nombre = pais.NombrePais
                                                }).ToArray(),
                                      Productos = (from prd in _context.Producto
                                      where prd.ActividadPTId == apt.CodigoActividadPT
                                            select new MapDTO()
                                            {
                                                Id = prd.codigoProducto,
                                                Nombre = prd.NombreProducto
                                            }).ToArray()
                                  }
                             ).ToArray()
                        
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