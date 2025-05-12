using CocQuery.Models.Coc;
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
            //ItemTappedCommand = new Command<Clan>(OnItemClicked);
            SearchCommand = new AsyncRelayCommand(Search);
            SearchFilterVisibleCommand = new AsyncRelayCommand(SearchFilterVisible);
            _clans = new ObservableCollection<Models.Coc.Clan>();

            Locations = new ObservableCollection<Location>()
            {
                new Location { DisplayName = "全球范围", Value = "32000006" },
                new Location { DisplayName = "中国", Value = "32000056" },
                new Location { DisplayName = "欧洲", Value = "32000000" },
                new Location { DisplayName = "亚洲", Value = "32000003" }

            };
            WarFrequencys = new ObservableCollection<WarFrequency>()
            {
                new WarFrequency (){ Value="Always",DisplayName="始终"},
                new WarFrequency (){ Value="Never",DisplayName="从不"},
                new WarFrequency (){ Value="MoreThanOncePerWeek",DisplayName="一周两次"},
                new WarFrequency (){ Value="OncePerWeek",DisplayName="一周一次"},
                new WarFrequency (){ Value="LessThanOncePerWeek",DisplayName="很少"},
                new WarFrequency (){ Value="Unkown",DisplayName="任何"},
            };
        }
        public async Task OnItemClicked(Clan clan)
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
                    #region 过滤变量
                    string? warFrequency = null;
                    int? locationId = null;
                    if(SelectedWarFrequency != null)
                    {
                        warFrequency = SelectedWarFrequency.Value;
                    }
                    if(SelectedLocation != null)
                    {
                        locationId= int.Parse(SelectedLocation.Value);
                    }
                    #endregion
                    var responseResult = await clansService.GetClansAsync(SearchText, warFrequency, locationId, null, null, null, null, 100, null, null, null);
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

        #region 对战频率属性
        private ObservableCollection<WarFrequency> _warFrequencys;
        public ObservableCollection<WarFrequency> WarFrequencys
        {
            get { return _warFrequencys; }
            set
            {
                _warFrequencys = value;
                OnPropertyChanged(nameof(WarFrequencys));
            }
        }

        private Location _selectedWarFrequency;
        public Location SelectedWarFrequency
        {
            get => _selectedWarFrequency;
            set
            {
                if (_selectedWarFrequency != value)
                {
                    _selectedWarFrequency = value;
                    OnPropertyChanged(nameof(SelectedWarFrequency));
                }
            }
        }
        #endregion

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

        //private Clan _selectedClan;

        //public Clan SelectedClan
        //{
        //    get => _selectedClan;
        //    set
        //    {
        //        if (_selectedClan != value)
        //        {
        //            _selectedClan = value;
        //            OnPropertyChanged(nameof(SelectedClan));
        //            if (value != null)
        //            {
        //                ItemTappedCommand.Execute(value);
        //            }
        //        }
        //    }
        //}
        //public ICommand ItemTappedCommand { get; private set; }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class Location
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
    public class WarFrequency
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
