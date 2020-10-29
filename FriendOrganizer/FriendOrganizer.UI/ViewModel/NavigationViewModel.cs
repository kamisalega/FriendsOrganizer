﻿using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganizer.UI.Event;
using Prism.Events;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookupDataService _friendLookupDataService;
        private IEventAggregator _eventAggregator;
        private LookupItem _selectedFriend;

        public NavigationViewModel(IFriendLookupDataService friendLookupDataService, IEventAggregator eventAggregator)
        {
            _friendLookupDataService = friendLookupDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<LookupItem>();
        }

        public ObservableCollection<LookupItem> Friends { get; }
     

        public LookupItem SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
                if (_selectedFriend != null)
                {
                    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                        .Publish(_selectedFriend.Id);
                }
            }
        }


        public async Task LoadAsync()
        {
            var lookup = await _friendLookupDataService.GetFirendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(item);
            }
        }

    }
}
 