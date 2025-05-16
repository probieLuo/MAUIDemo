using CocQuery.Models.Coc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocQuery.ViewModels
{
    public class PlayerDetailViewModel : INotifyPropertyChanged
    {
        public PlayerDetailViewModel(Player player)
        {
            Player = player;
        }

        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                if (_player != value)
                {
                    _player = value;
                    OnPropertyChanged(nameof(Player));
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

        internal async Task OnItemClicked(PlayerClan? clan)
        {
            try
            {
                ActivityIndicatorIsRunning = true;
                ActivityIndicatorIsVisible = true;
                if (clan != null)
                {
                    Services.Coc.ClansService clansService = new Services.Coc.ClansService();

                    var responseResult = await clansService.GetClanAsync(clan.Tag);
                    Clan clan1 = responseResult.Data;
                    // 跳转到详细页面
                    await Application.Current.MainPage.Navigation.PushAsync(new Views.ClanDetailPage(clan1));
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

        #region 处理活动指示器的显示和隐藏
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
        #endregion
    }
}
