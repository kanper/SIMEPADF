using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Model.Domain;

namespace Services
{
    public interface IAlertService
    {
        IEnumerable<AlertaDTO> FindAll(string rol, string pais);
        bool MarkAsRead(int id);
        bool CreateAlert(AlertaDTO dto);
    }
    
    public class AlertService : IAlertService
    {

        private readonly simepadfContext _context;

        public AlertService(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<AlertaDTO> FindAll(string rol, string pais)
        {
            try
            {
                return (from a in _context.Alertas
                    where a.Revisado == false &&
                          (a.Rol == rol || a.Rol == "ALL") &&
                          (a.Pais == pais || a.Pais == "ALL")
                    select new AlertaDTO()
                    {
                        Id = a.Id,
                        Titulo = a.Titulo,
                        Mensaje = a.Mensaje,
                        Tipo = a.Tipo,
                        NombreUsuario = a.Usuario,
                        Fecha = a.Inicio
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<AlertaDTO>();
            }
        }

        public bool MarkAsRead(int id)
        {
            try
            {
                _context.Alertas.Single(a => a.Id == id).Revisado = true;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool CreateAlert(AlertaDTO dto)
        {
            try
            {
                foreach (var s in dto.Rol.Split('$'))
                {
                    foreach (var s1 in dto.Pais.Split('$'))
                    {
                        _context.Alertas.Add(new Alerta(dto.Titulo, dto.Mensaje, dto.Tipo, s, s1, dto.NombreUsuario));
                        _context.SaveChanges();
                    }
                }                
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