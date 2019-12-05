using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IAlertService
    {
        IEnumerable<AlertaDTO> FindAll(string rol, string pais);
        bool MarkAsRead(int id);
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
                          a.Rol == rol &&
                          a.Pais == pais
                    select new AlertaDTO()
                    {
                        Id = a.Id,
                        Mensaje = a.Mensaje,
                        Tipo = a.Tipo
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
    }
}