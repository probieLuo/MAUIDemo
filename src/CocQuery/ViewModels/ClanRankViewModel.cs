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
