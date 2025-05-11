using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CocQuery.ViewModels
{
    internal class ClanSearchViewModel : INotifyPropertyChanged
    {
        public ClanSearchViewModel()
        {
            SearchCommand = new AsyncRelayCommand(Search);
            SearchFilterVisibleCommand = new AsyncRelayCommand(SearchFilterVisible);
            _clans = new ObservableCollection<Models.Coc.Clan>();
        }

        private async Task SearchFilterVisible(object arg)
        {
            if (SearchFilterIsVisible == Visibility.Collapsed)
            {
                SearchFilterIsVisible = Visibility.Visible;
            }
            else
            {
                SearchFilterIsVisible = Visibility.Collapsed;
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
                    Services.Coc.ClansService clansService = new Services.Coc.ClansService();

                    var responseResult = await clansService.GetClanAsync(SearchText);
                    if (responseResult.Data != null)
                    {
                        Clans.Clear();
                        Clans.Add(responseResult.Data);
                    }
                }
                else
                {
                    Services.Coc.ClansService clansService = new Services.Coc.ClansService();
                    var responseResult = await clansService.GetClansAsync(SearchText, null, null, null, null, null, null, 100, null, null, null);
                    if (responseResult.Data != null && responseResult.Data.Items != null)
                    {
                        Clans.Clear();
                        foreach (var clan in responseResult.Data.Items)
                        {
                            Clans.Add(clan);
                        }
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

                SearchFilterIsVisible = Visibility.Collapsed;
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

        private Visibility searchFilterIsVisible = Visibility.Visible;
        public Visibility SearchFilterIsVisible
        {
            get { return searchFilterIsVisible; }
            set
            {
                searchFilterIsVisible = value;
                OnPropertyChanged(nameof(SearchFilterIsVisible));
            }
        }

        public ICommand SearchCommand { get; private set; }
        public ICommand SearchFilterVisibleCommand { get; private set; }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
