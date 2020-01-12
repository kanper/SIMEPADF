using System.Collections.Generic;

namespace Auth.Models
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<Auth.Models.EmailAddress>();
            FromAddresses = new List<Auth.Models.EmailAddress>();
        }
 
        public List<Auth.Models.EmailAddress> ToAddresses { get; set; }
        public List<Auth.Models.EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}