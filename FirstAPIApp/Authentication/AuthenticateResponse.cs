using FirstAPIApp.DTOs;

namespace FirstAPIApp.Authentication
{
    public class AuthenticateResponse
    {
        public Guid IdMember { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Member user, string token)
        {
            IdMember = user.IdMember;
            Name = user.Name;
            Title = user.Title;
            Token = token;
        }
    }
}
