using CocQuery.Models.Coc;
using System.ComponentModel;

namespace CocQuery.ViewModels
{
    public class ClanDetailViewModel: INotifyPropertyChanged
    {
        public ClanDetailViewModel(Clan clan)
        {
            Clan = clan;
        }

        private Clan _clan;
        public Clan Clan
        {
            get
            {
                return _clan;
            }
            set
            {
                if (_clan != value)
                {
                    _clan = value;
                    OnPropertyChanged(nameof(Clan));
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
