using FirstAPIApp.DataContext;
using FirstAPIApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp.Repositories
{
    public class MembershipTypesRepository : IMembershipTypesRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public MembershipTypesRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypesAsync()
        {
            return await _context.MembershipTypes.ToListAsync();
        }
    }
}
