﻿using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class LookupDataService : IFriendLookupDataService
    {
        private Func<FriendOrganizerDbContex> _contextCreator;

        public LookupDataService(Func<FriendOrganizerDbContex> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetFirendLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Friends.AsNoTracking().Select(f => new LookupItem
                {
                    Id = f.Id,
                    DisplayMemeber = f.FirstName + " " + f.LastName
                }).ToListAsync();
            }
        }
    }
}
