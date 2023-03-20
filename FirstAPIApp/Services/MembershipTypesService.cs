using FirstAPIApp.DTOs;
using FirstAPIApp.Repositories;

namespace FirstAPIApp.Services
{
    public class MembershipTypesService : IMembershipTypesService
    {
        private readonly IMembershipTypesRepository _repository;

        public MembershipTypesService(IMembershipTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypesAsync()
        {
            return await _repository.GetMembershipTypesAsync();
        }
    }
}
