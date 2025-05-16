using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class ClanRankPage : ContentPage
{
	public ClanRankPage()
	{
		InitializeComponent();
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Models.Coc.ClanRanking clanRanking && BindingContext is ClanRankViewModel viewModel)
        {
            await viewModel.OnItemClicked(clanRanking);
        }
    }
}