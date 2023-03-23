using AutoMapper;
using FirstAPIApp.DataContext;
using FirstAPIApp.DTOs;
using FirstAPIApp.DTOs.CreateUpdateObjects;
using FirstAPIApp.DTOs.PatchObjects;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApp.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;

        private readonly IMapper _mapper;

        public AnnouncementsRepository(ProgrammingClubDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _context.Announcements.SingleOrDefaultAsync(a => a.IdAnnouncement == id);
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

        public async Task CreateAnnouncementAsync(Announcement announcement)
        {
            announcement.IdAnnouncement = Guid.NewGuid();
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            Announcement announcement = await GetAnnouncementByIdAsync(id);
            if (announcement == null)
            {
                return false;
            }
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement)
        {
            if (!await ExistAnnouncementAsync(id))
            {
                return null;
            }

            //announcementFromDb.EventDate = announcement.EventDate;
            //announcementFromDb.Text = announcement.Text;
            //announcementFromDb.Title = announcement.Title;
            //announcementFromDb.ValidFrom = announcement.ValidFrom;
            //announcementFromDb.ValidTo = announcement.ValidTo;
            //announcementFromDb.Tags = announcement.Tags;

            var updatedAnnouncement = _mapper.Map<Announcement>(announcement);
            updatedAnnouncement.IdAnnouncement = id;
            _context.Update(updatedAnnouncement);
            await _context.SaveChangesAsync();
            return announcement;
        }

        public async Task<PatchAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, PatchAnnouncement announcement)
        {
            var announcementFromDb = await GetAnnouncementByIdAsync(id);
            if (announcementFromDb == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(announcement.Title) && announcement.Title != announcementFromDb.Title)
            {
                announcementFromDb.Title = announcement.Title;
            }
            if (!string.IsNullOrEmpty(announcement.Text) && announcement.Text != announcementFromDb.Text)
            {
                announcementFromDb.Text = announcement.Text;
            }
            if (!string.IsNullOrEmpty(announcement.Tags) && announcement.Tags != announcementFromDb.Tags)
            {
                announcementFromDb.Tags = announcement.Tags;
            }
            if (announcement.ValidFrom.HasValue && announcement.ValidFrom != announcementFromDb.ValidFrom)
            {
                announcementFromDb.ValidFrom = announcement.ValidFrom;
            }
            if (announcement.ValidTo.HasValue && announcement.ValidTo != announcementFromDb.ValidTo)
            {
                announcementFromDb.ValidTo = announcement.ValidTo;
            }
            if (announcement.EventDate.HasValue && announcement.EventDate != announcementFromDb.EventDate)
            {
                announcementFromDb.EventDate = announcement.EventDate;
            }

            _context.Announcements.Update(announcementFromDb);
            await _context.SaveChangesAsync();
            return announcement;
        }
        private async Task<bool> ExistAnnouncementAsync(Guid id)
        {
            return await _context.Announcements.CountAsync(a => a.IdAnnouncement == id) > 0;
        }
    }
}
