using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class PlayerRankPage : ContentPage
{
	public PlayerRankPage()
	{
		InitializeComponent();
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Models.Coc.PlayerRanking playerRanking && BindingContext is PlayerRankViewModel viewModel)
        {
            await viewModel.OnItemClicked(playerRanking);
        }
    }
}