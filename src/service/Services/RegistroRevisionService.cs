using System.Collections.Generic;
using DTO.DTO;

namespace Services
{

    public interface IRegistroRevisionService
    {
        IEnumerable<RegistroRevisionDTO> GetAll(string id, string status);
    }
    
    public class RegistroRevisionService
    {
        
    }
}