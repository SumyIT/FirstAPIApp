using System.ComponentModel.DataAnnotations;

namespace FirstAPIApp.Authentication
{
    public class AuthenticateRequest
    {
        [Required]
        public Guid Username { get; set; }   //idMember - tabela Member

        [Required]
        public string Password { get; set; }   //name - tabela Member
    }
}
