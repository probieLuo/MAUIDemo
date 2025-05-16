using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class PlayerSearchPage : ContentPage
{
	public PlayerSearchPage()
	{
		InitializeComponent();
	}

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Models.Coc.Player clan && BindingContext is PlayerSearchViewModel viewModel)
        {
            await viewModel.OnItemClicked(clan);
            
        }
    }
}