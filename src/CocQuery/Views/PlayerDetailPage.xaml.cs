using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class PlayerDetailPage : ContentPage
{
	public PlayerDetailPage(CocQuery.Models.Coc.Player player)
	{
		InitializeComponent();
        BindingContext = new PlayerDetailViewModel(player);

        // 动态恢复导航栏显示
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
            // 复制 Tag 到剪贴板
            Clipboard.SetTextAsync(PlayTag.Text);
            DisplayAlert("复制成功", $"已将 {PlayTag.Text} 复制到剪贴板", "确定");
        }
        else
        {
            DisplayAlert("错误", "无法获取 Player 数据", "确定");
        }
    }
}