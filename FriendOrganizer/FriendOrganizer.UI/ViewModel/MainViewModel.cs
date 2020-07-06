using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.Windows.Navigation;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IFriendDataService _friendDataService;
        private Friend _selectedFriend;

        public ObservableCollection<Friend> Friends { get; set; }
      

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set { _selectedFriend = value; }
        }

        public MainViewModel(IFriendDataService friendDataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
        }
        
        public void Load()
        {
            var friends = _friendDataService.GetAll();
            Friends.Clear();

            foreach(var friend in friends)
            {
                Friends.Add(friend);
                OnPropertyChanged();
            }

        }        
    }
}
