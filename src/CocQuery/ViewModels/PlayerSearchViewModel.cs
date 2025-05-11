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

        private async Task Search(object arg)
        {
            if (_searchText.StartsWith("#"))
            {
                HttpRestClient client = new HttpRestClient();
                var request = new BaseRequest()
                {
                    Uri = $"players/{_searchText}",
                };
                var player = await client.RequestAsync<Services.Coc.BaseResponseResult<Models.Coc.Player>>(request);
                if (player.Data != null)
                {
                    Players.Clear();
                    Players.Add(player.Data);
                }
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
