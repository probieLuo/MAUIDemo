using CocQuery.Models.Coc;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CocQuery.ViewModels
{
    public class PlayerRankViewModel : INotifyPropertyChanged
    {
        public PlayerRankViewModel()
        {
            RefreshCommand = new AsyncRelayCommand(Refresh);
            SearchCommand = new AsyncRelayCommand(Search);
            _palyers = new PlayerRankingList();

            _ = Search(new object());

            Locations = new ObservableCollection<Location>()
            {
                new Location { DisplayName = "全球范围", Value = "32000006" },
                new Location { DisplayName = "中国", Value = "32000056" },
                new Location { DisplayName = "欧洲", Value = "32000000" },
                new Location { DisplayName = "亚洲", Value = "32000003" }

            };
        }
        private async Task Refresh(object arg)
        {
            IsRefreshing = false;
            await Search(null);
        }
        public async Task OnItemClicked(PlayerRanking player)
        {
            try
            {
                ActivityIndicatorIsRunning = true;
                ActivityIndicatorIsVisible = true;
                if (player != null)
                {
                    Services.Coc.PlayersService playersService = new Services.Coc.PlayersService();

                    var responseResult = await playersService.GetPlayerAsync(player.Tag);
                    Player player1 = responseResult.Data;
                    // 跳转到详细页面
                    await Application.Current.MainPage.Navigation.PushAsync(new Views.PlayerDetailPage(player1));
                }
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
        private async Task Search(object arg)
        {
            try
            {
                ActivityIndicatorIsRunning = true;
                ActivityIndicatorIsVisible = true;
                /*
                Services.Coc.LocationsService locationsService = new Services.Coc.LocationsService();
                #region 过滤条件
                int locationId = 32000056;
                int? limit = 100;
                string? after = null;
                string? before = null;
                if (SelectedLocation != null)
                {
                    locationId = int.Parse(SelectedLocation.Value);
                }
                #endregion
                var responseResult = await locationsService.GetPlayerRankingAsync(locationId, limit, after, before);

                if (responseResult != null && responseResult.Data != null && responseResult.Data.Items != null)
                {
                    Players = responseResult.Data.Items;
                }
                */

                int locationId = 32000056;
                if (SelectedLocation != null)
                {
                    locationId = int.Parse(SelectedLocation.Value);
                }
                Services.Cache.PersistentCacheService_PlayerRank cacheService = new Services.Cache.PersistentCacheService_PlayerRank(locationId.ToString());
                var cacheData = await cacheService.GetCollection();
                Players = cacheData;
            }
            catch (Exception e)
            {
#if DEBUG
                throw e;
#endif
            }
            finally
            {
                IsRefreshing = false;
                ActivityIndicatorIsRunning = false;
                ActivityIndicatorIsVisible = false;
            }
        }

        private PlayerRankingList _palyers;
        public PlayerRankingList Players
        {
            get
            {
                return _palyers;
            }
            set
            {
                _palyers = value;
                OnPropertyChanged(nameof(Players));
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


        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand { get; private set; }
    }
}
