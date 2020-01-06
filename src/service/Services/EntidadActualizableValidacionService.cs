using System;
using DatabaseContext;

namespace Services
{
    public interface IEntidadActualizableValidacionService
    {
        bool IsProductoActualizable(int id);

    }
    
    public class EntidadActualizableValidacionService : IEntidadActualizableValidacionService
    {
        private readonly simepadfContext _context;

        public EntidadActualizableValidacionService(simepadfContext context)
        {
            _context = context;
        }

        public bool IsProductoActualizable(int id)
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
    }
}