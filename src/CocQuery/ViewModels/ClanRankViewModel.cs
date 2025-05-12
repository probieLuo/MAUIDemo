using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CocQuery.ViewModels
{
    public class ClanRankViewModel : INotifyPropertyChanged
    {
        public ClanRankViewModel()
        {
            SearchCommand = new AsyncRelayCommand(Search);
            _clans = new ObservableCollection<Models.Coc.Clan>();

            Search(new object());

            Locations = new ObservableCollection<Location>()
            {
                new Location { DisplayName = "全球范围", Value = "32000006" },
                new Location { DisplayName = "中国", Value = "32000056" },
                new Location { DisplayName = "欧洲", Value = "32000000" },
                new Location { DisplayName = "亚洲", Value = "32000003" }

            };
        }
        private async Task Search(object arg)
        {
            try
            {
                ActivityIndicatorIsRunning = true;
                ActivityIndicatorIsVisible = true;

                Services.Coc.LocationsService locationsService = new Services.Coc.LocationsService();



            }
            catch (Exception e)
            {
#if DEBUG
                throw e;
#endif
            }
            finally
            {
                ActivityIndicatorIsRunning = false;
                ActivityIndicatorIsVisible = false;
            }
        }

        private ObservableCollection<Models.Coc.Clan> _clans;
        public ObservableCollection<Models.Coc.Clan> Clans
        {
            get
            {
                return _clans;
            }
            set
            {
                _clans = value;
                OnPropertyChanged(nameof(_clans));
            }
        }

        private bool activityIndicatorIsRunning = false;
        public bool ActivityIndicatorIsRunning
        {
            get { return activityIndicatorIsRunning; }
            set
            {
                activityIndicatorIsRunning = value;
                OnPropertyChanged(nameof(ActivityIndicatorIsRunning));
            }
        }
        private bool activityIndicatorIsVisible = false;
        public bool ActivityIndicatorIsVisible
        {
            get { return activityIndicatorIsVisible; }
            set
            {
                activityIndicatorIsVisible = value;
                OnPropertyChanged(nameof(ActivityIndicatorIsVisible));
            }
        }
        #region 部落位置
        private ObservableCollection<Location> _locations;
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }


        private Location _selectedLocation;
        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                if (_selectedLocation != value)
                {
                    _selectedLocation = value;
                    OnPropertyChanged(nameof(SelectedLocation));
                }
            }
        }
        #endregion
        public ICommand SearchCommand { get; private set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
