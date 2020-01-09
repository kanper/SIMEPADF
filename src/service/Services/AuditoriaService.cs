using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO;
using DTO.DTO;
using Model.Domain.DbHelper;

namespace Services
{

    public interface IAuditoriaService
    {
        IEnumerable<AuditoriaDTO> GetAll();
        IEnumerable<AuditoriaDTO> GetActividadPlanTrabajo();
        IEnumerable<AuditoriaDTO> GetDesagregacion();
        IEnumerable<AuditoriaDTO> GetFuenteDato();
        IEnumerable<AuditoriaDTO> GetIndicador();
        IEnumerable<AuditoriaDTO> GetActividad();
        IEnumerable<AuditoriaDTO> GetResultado();
        IEnumerable<AuditoriaDTO> GetObjetivo();
        IEnumerable<AuditoriaDTO> GetNivelImpacto();
        IEnumerable<AuditoriaDTO> GetOrganizacionResponsable();
        IEnumerable<AuditoriaDTO> GetPais();
        IEnumerable<AuditoriaDTO> GetProducto();
        IEnumerable<AuditoriaDTO> GetProyecto();
        IEnumerable<AuditoriaDTO> GetSocioInternacional();

    }

    public class AuditoriaService : IAuditoriaService
    {
        private const string _CREATE = "Creación";
        private const string _UPDATE = "Actualización";
        private const string _DELETE = "Eliminación";
        private string TABLENAME;
        private List<AuditoriaDTO> Result = new List<AuditoriaDTO>();
        private readonly simepadfContext _context;

        public AuditoriaService(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<AuditoriaDTO> GetAll()
        {
            try
            {
                var All = new List<AuditoriaDTO>();
                All.AddRange(GetActividad());
                All.AddRange(GetActividadPlanTrabajo());
                All.AddRange(GetDesagregacion());
                All.AddRange(GetFuenteDato());
                All.AddRange(GetIndicador());
                All.AddRange(GetResultado());
                All.AddRange(GetObjetivo());
                All.AddRange(GetNivelImpacto());
                All.AddRange(GetOrganizacionResponsable());
                All.AddRange(GetPais());
                All.AddRange(GetProducto());
                All.AddRange(GetProyecto());
                All.AddRange(GetSocioInternacional());
                return All.OrderByDescending(a => a.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetActividad()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Actividad";
                foreach (var actividad in _context.Actividad.ToList())
                {
                    AddCreationAudit(actividad,actividad.NombreActividad);
                    AddUpdateAudit(actividad, actividad.NombreActividad);
                    AddDeleteAudit(actividad, actividad.NombreActividad);
                };
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetActividadPlanTrabajo()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Actividad Plan de Trabajo";
                foreach (var plan in _context.ActividadPT.ToList())
                {
                    AddCreationAudit(plan,plan.NombreActividad);
                    AddUpdateAudit(plan, plan.NombreActividad);
                    AddDeleteAudit(plan, plan.NombreActividad);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetDesagregacion()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Desagregación";
                foreach (var des in _context.Desagregacion.ToList())
                {
                    AddCreationAudit(des,des.TipoDesagregacion);
                    AddUpdateAudit(des, des.TipoDesagregacion);
                    AddDeleteAudit(des, des.TipoDesagregacion);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetFuenteDato()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Fuente de dato";
                foreach (var fuente in _context.FuenteDato.ToList())
                {
                    AddCreationAudit(fuente,fuente.NombreFuente);
                    AddUpdateAudit(fuente, fuente.NombreFuente);
                    AddDeleteAudit(fuente, fuente.NombreFuente);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetIndicador()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Indicador";
                foreach (var ind in _context.Indicador.ToList())
                {
                    AddCreationAudit(ind,ind.NombreIndicador);
                    AddUpdateAudit(ind, ind.NombreIndicador);
                    AddDeleteAudit(ind, ind.NombreIndicador);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetResultado()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Resultado";
                foreach (var res in _context.Resultado.ToList())
                {
                    AddCreationAudit(res,res.NombreResultado);
                    AddUpdateAudit(res, res.NombreResultado);
                    AddDeleteAudit(res, res.NombreResultado);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetObjetivo()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Objetivo";
                foreach (var obj in _context.Objetivo.ToList())
                {
                    AddCreationAudit(obj,obj.NombreObjetivo);
                    AddUpdateAudit(obj, obj.NombreObjetivo);
                    AddDeleteAudit(obj, obj.NombreObjetivo);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetNivelImpacto()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Nivel de Impacto";
                foreach (var nivel in _context.NivelImpacto.ToList())
                {
                    AddCreationAudit(nivel,nivel.NombreNivelImpacto);
                    AddUpdateAudit(nivel, nivel.NombreNivelImpacto);
                    AddDeleteAudit(nivel, nivel.NombreNivelImpacto);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetOrganizacionResponsable()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Organización Responsable";
                foreach (var org in _context.OrganizacionResponsable.ToList())
                {
                    AddCreationAudit(org,org.NombreOrganizacion);
                    AddUpdateAudit(org, org.NombreOrganizacion);
                    AddDeleteAudit(org, org.NombreOrganizacion);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetPais()
        {
            try
            {
                Result.Clear();
                TABLENAME = "País";
                foreach (var pais in _context.Pais.ToList())
                {
                    AddCreationAudit(pais,pais.NombrePais);
                    AddUpdateAudit(pais, pais.NombrePais);
                    AddDeleteAudit(pais, pais.NombrePais);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetProducto()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Producto";
                foreach (var pro in _context.Producto.ToList())
                {
                    AddCreationAudit(pro,pro.NombreProducto);
                    AddUpdateAudit(pro, pro.NombreProducto);
                    AddDeleteAudit(pro, pro.NombreProducto);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetProyecto()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Proyecto";
                foreach (var pro in _context.Proyecto.ToList())
                {
                    AddCreationAudit(pro,pro.NombreProyecto);
                    AddUpdateAudit(pro, pro.NombreProyecto);
                    AddDeleteAudit(pro, pro.NombreProyecto);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        public IEnumerable<AuditoriaDTO> GetSocioInternacional()
        {
            try
            {
                Result.Clear();
                TABLENAME = "Socio Internacional";
                foreach (var socio in _context.SocioInternacional.ToList())
                {
                    AddCreationAudit(socio,socio.NombreSocio);
                    AddUpdateAudit(socio, socio.NombreSocio);
                    AddDeleteAudit(socio, socio.NombreSocio);
                }
                return Result.OrderByDescending(r => r.DateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AuditoriaDTO>();
            }
        }

        private void AddCreationAudit(AudityEntity entity, string identifier)
        {
            if(entity.CreatedAt.HasValue)
                Result.Add(new AuditoriaDTO(entity.CreatedBy,_CREATE,TABLENAME,identifier,entity.CreatedAt.GetValueOrDefault()));
        }

        private void AddUpdateAudit(AudityEntity entity, string identifier)
        {
            if(entity.UpdatedAt.HasValue)
                Result.Add(new AuditoriaDTO(entity.UpdatedBy,_UPDATE,TABLENAME,identifier,entity.UpdatedAt.GetValueOrDefault()));
        }

        private void AddDeleteAudit(AudityEntity entity, string identifier)
        {
            if(entity.DeletedAt.HasValue)
                Result.Add(new AuditoriaDTO(entity.DeletedBy,_DELETE,TABLENAME,identifier,entity.DeletedAt.GetValueOrDefault()));
        }
    }
}