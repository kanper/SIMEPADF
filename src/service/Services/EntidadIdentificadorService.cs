using DatabaseContext;

namespace Services
{
    public interface IEntidadIdentificadorService
    {
        
    }
    
    public class EntidadIdentificadorService : IEntidadIdentificadorService
    {
        private readonly simepadfContext _context;

        public EntidadIdentificadorService(simepadfContext context)
        {
            _context = context;
        }
    }
}