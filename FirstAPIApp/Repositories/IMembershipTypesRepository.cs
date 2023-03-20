using FirstAPIApp.DTOs;

namespace FirstAPIApp.Repositories
{
    public interface IMembershipTypesRepository
    {
        public Task<IEnumerable<MembershipType>> GetMembershipTypesAsync();
    }
}
