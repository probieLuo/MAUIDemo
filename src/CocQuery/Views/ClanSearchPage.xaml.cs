using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class ClanSearchPage : ContentPage
{
    public ClanSearchPage()
    {
        InitializeComponent();
    }

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Models.Coc.Clan clan && BindingContext is ClanSearchViewModel viewModel)
        {
            await viewModel.OnItemClicked(clan);
            //if (clan != null)
            //{
            //    // ��ת����ϸҳ��
            //    await Application.Current.MainPage.Navigation.PushAsync(new Views.ClanDetailPage(clan));
            //}
        }
    }
}