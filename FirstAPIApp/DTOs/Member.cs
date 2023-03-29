using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstAPIApp.DTOs
{
    public class Member
    {
        [Key]
        public Guid IdMember { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        public string Resume { get; set; }
    }
}
