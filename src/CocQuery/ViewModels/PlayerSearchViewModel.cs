using CocQuery.Services.Coc;
using RestSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CocQuery.ViewModels
{
    internal class PlayerSearchViewModel:INotifyPropertyChanged
    {
        public PlayerSearchViewModel()
        {
            SearchCommand=new AsyncRelayCommand(Search);
            _players = new ObservableCollection<Player>();
            _players.Add(new Player() { Name="probie菜潦",Description= "probie菜潦", Image= "https://api-assets.clashofclans.com/leagues/72/qVCZmeYH0lS7Gaa6YoB7LrNly7bfw7fV_d4Vp2CU-gk.png" });
            _players.Add(new Player() { Name = "probie菜潦", Description = "probie菜潦", Image = "https://api-assets.clashofclans.com/leagues/72/qVCZmeYH0lS7Gaa6YoB7LrNly7bfw7fV_d4Vp2CU-gk.png" });
        }

        private async Task Search(object arg)
        {
            HttpRestClient client = new HttpRestClient();
            var request = new BaseRequest()
            {
                Uri = $"players/{_searchText}",
            };
            var player = await client.RequestAsync<Services.Coc.BaseResponseResult<Models.Coc.Player>>(request);

        }

        private ObservableCollection<Player> _players;
        public ObservableCollection<Player> Players
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

        public ICommand SearchCommand { get;private set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class Player
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
