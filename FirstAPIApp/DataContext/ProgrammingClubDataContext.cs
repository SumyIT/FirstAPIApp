using Microsoft.EntityFrameworkCore;
using FirstAPIApp.DTOs;

namespace FirstAPIApp.DataContext
{
    public class ProgrammingClubDataContext : DbContext
    {
        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options) { }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Member> Members { get; set; }
        //public DbSet<Membership> Memberships { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        //public DbSet<CodeSnippet> CodeSnippets { get; set; }
    }
}
