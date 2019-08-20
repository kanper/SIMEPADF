using System;

namespace DTO.DTO
{
    public class PersonalDTO
    {
        public string Id { get; set; }
        public string NombrePersonal { get; set; }
        public string ApellidoPersonal { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaAfilacion { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Pais { get; set; }
        public string newPassword { get; set; }

        //rol
        public string Name { get; set; }
    }
}
