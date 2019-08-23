using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IProyectoInfoService
    {
        ProyectoInfoDTO Get(int id);
        ICollection<ProyectoInfoDTO> GetAll(string id);
    }
    
    public class ProyectoInfoService : IProyectoInfoService
    {
        private readonly simepadfContext _context;

        public ProyectoInfoService(simepadfContext context)
        {
            _context = context;
        }

        public ProyectoInfoDTO Get(int id)
        {
            try
            {
                return (from  a in _context.ActividadPT                                            
                    where a.CodigoActividadPT == id
                    select new ProyectoInfoDTO()
                    {
                        CodigoActividad = a.CodigoActividadPT,                               
                        NombreActividad = a.NombreActividad,                               
                        Monto = a.Monto,
                        FechaLimite = a.FechaLimite,
                        Productos = (from p in _context.Producto
                            where p.ActividadPTId == a.CodigoActividadPT
                            select new MapDTO()
                            {
                                Id = p.codigoProducto,
                                Nombre = p.NombreProducto
                            }).ToArray()
                               
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ICollection<ProyectoInfoDTO> GetAll(string id)
        {
            try
            {
                return (from plan in _context.PlanTrabajo
                    join a in _context.ActividadPT 
                        on plan equals a.PlanTrabajo                   
                    where plan.CodigoPlanTrabajo == id
                    select new ProyectoInfoDTO()
                    {
                               CodigoActividad = a.CodigoActividadPT,                               
                               NombreActividad = a.NombreActividad,                               
                               Monto = a.Monto,
                               FechaLimite = a.FechaLimite,
                               Productos = (from p in _context.Producto
                                       where p.ActividadPTId == a.CodigoActividadPT
                                             select new MapDTO()
                                             {
                                                 Id = p.codigoProducto,
                                                 Nombre = p.NombreProducto
                                             }).ToArray()
                               
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoInfoDTO>();                
            }
        }
    }
}