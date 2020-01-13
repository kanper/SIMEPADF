using System;

namespace Auth.Models
{
    public class RecoveryInputModel
    {
        public RecoveryInputModel()
        {
        }

        public RecoveryInputModel(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
        public string Codigo { get; set; }
        public bool IsValidEmail { get; set; }
        public bool IsValidCode { get; set; }
        public DateTime ValidStart { get; set; }
        public DateTime ValidEnd { get; set; }
    }
}