using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class PlayerDetailPage : ContentPage
{
	public PlayerDetailPage(CocQuery.Models.Coc.Player player)
	{
		InitializeComponent();
        BindingContext = new PlayerDetailViewModel(player);

        // ��̬�ָ���������ʾ
        Shell.SetNavBarIsVisible(this, true);
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (BindingContext is PlayerDetailViewModel viewModel)
        {
            await viewModel.OnItemClicked(viewModel.Player.Clan);
        }
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        
        if (!string.IsNullOrEmpty(PlayTag.Text))
        {
            // ���� Tag ��������
            Clipboard.SetTextAsync(PlayTag.Text);
            DisplayAlert("���Ƴɹ�", $"�ѽ� {PlayTag.Text} ���Ƶ�������", "ȷ��");
        }
        else
        {
            DisplayAlert("����", "�޷���ȡ Player ����", "ȷ��");
        }
    }
}