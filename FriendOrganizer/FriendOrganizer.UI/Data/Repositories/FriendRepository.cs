using System;
using System.Data.Entity;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private FriendOrganizerDbContex _context;

        public FriendRepository(FriendOrganizerDbContex context)
        {
            _context = context;
        }
        public async Task<Friend> GetByIdAsync(int friendId)
        {
            return await _context.Friends.SingleAsync(f => f.Id == friendId);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
