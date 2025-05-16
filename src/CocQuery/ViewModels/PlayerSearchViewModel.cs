using CocQuery.Models.Coc;
using CocQuery.Services.Coc;
using RestSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CocQuery.ViewModels
{
    internal class PlayerSearchViewModel : INotifyPropertyChanged
    {
        public PlayerSearchViewModel()
        {
            SearchCommand = new AsyncRelayCommand(Search);
            _players = new ObservableCollection<Models.Coc.Player>();
        }
        public async Task OnItemClicked(Player player)
        {
            try
            {
                ActivityIndicatorIsRunning = true;
                ActivityIndicatorIsVisible = true;
                if (player != null)
                {

                    // 跳转到详细页面
                    await Application.Current.MainPage.Navigation.PushAsync(new Views.PlayerDetailPage(player));
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
                if (_searchText.StartsWith("#"))
                {
                    HttpRestClient client = new HttpRestClient();
                    var request = new BaseRequest()
                    {
                        Uri = $"players/{_searchText}",
                    };
                    var player = await client.RequestAsync<Services.Coc.BaseResponseResult<Models.Coc.Player>>(request);
                    if (player != null && player.Data != null)
                    {
                        Players.Clear();
                        Players.Add(player.Data);
                    }
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
        private ObservableCollection<Models.Coc.Player> _players;
        public ObservableCollection<Models.Coc.Player> Players
        {
            get
            {
                return _players;
            }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
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
