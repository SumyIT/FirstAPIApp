using FirstAPIApp.DataContext;
using FirstAPIApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }
    }
}
