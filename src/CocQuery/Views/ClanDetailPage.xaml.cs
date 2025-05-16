using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class ClanDetailPage : ContentPage
{
	
    public ClanDetailPage(Models.Coc.Clan clan)
    {
        InitializeComponent();
        BindingContext = new ClanDetailViewModel(clan);

        // 动态恢复导航栏显示
        Shell.SetNavBarIsVisible(this, true);
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Models.Coc.ClanMember clanMember && BindingContext is ClanDetailViewModel viewModel)
        {
            await viewModel.OnItemClicked(clanMember);
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (!string.IsNullOrEmpty(ClanTag.Text))
        {
            // 复制 Tag 到剪贴板
            Clipboard.SetTextAsync(ClanTag.Text);
            DisplayAlert("复制成功", $"已将 {ClanTag.Text} 复制到剪贴板", "确定");
        }
        else
        {
            DisplayAlert("错误", "无法获取 Player 数据", "确定");
        }

    }
    
}