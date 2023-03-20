using FirstAPIApp.DTOs;

namespace FirstAPIApp.Services
{
    public interface IMembershipTypesService
    {
        public Task<IEnumerable<MembershipType>> GetMembershipTypesAsync();
    }
}
