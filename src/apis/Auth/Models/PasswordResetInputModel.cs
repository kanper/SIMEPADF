namespace Auth.Models
{
    public class PasswordResetInputModel
    {
        public PasswordResetInputModel()
        {
        }

        public PasswordResetInputModel(string email)
        {
            Email = email;
            IsPasswordEquals = true;
            IsPasswordValid = true;
        }

        public PasswordResetInputModel(string email, string code)
        {
            Email = email;
            Code = code;
            IsPasswordEquals = true;
            IsPasswordValid = true;
        }

        public string NewPassword { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public bool IsPasswordValid { get; set; }
        public bool IsPasswordEquals { get; set; }
    }
}