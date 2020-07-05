using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Jan", LastName = "Kowalski" };
            yield return new Friend { FirstName = "Franciszek", LastName = "Sztacheta" };
            yield return new Friend { FirstName = "Julia", LastName = "Niedobra" };
            yield return new Friend { FirstName = "Krzysztof", LastName = "Jakiśtam" };
        }
    }
}
