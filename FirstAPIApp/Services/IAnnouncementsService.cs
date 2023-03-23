﻿using FirstAPIApp.DTOs;
using FirstAPIApp.DTOs.CreateUpdateObjects;
using FirstAPIApp.DTOs.PatchObjects;

namespace FirstAPIApp.Services
{
    public interface IAnnouncementsService
    {
        public Task<Announcement> GetAnnouncementByIdAsync(Guid id);

        public Task<IEnumerable<Announcement>> GetAnnouncementsAsync();

        public Task CreateAnnouncementAsync(Announcement newAnnouncement);

        public Task<bool> DeleteAnnouncementAsync(Guid id);

        public Task<CreateUpdateAnnouncement> UpdateAnnouncementAsync(Guid id, CreateUpdateAnnouncement announcement);

        public Task<PatchAnnouncement> UpdatePartiallyAnnouncementAsync(Guid id, PatchAnnouncement announcement);

    }
}
