using CocQuery.ViewModels;

namespace CocQuery.Views;

public partial class ClanDetailPage : ContentPage
{
	
    public ClanDetailPage(Models.Coc.Clan clan)
    {
        InitializeComponent();
        BindingContext = new ClanDetailViewModel(clan);

        // ��̬�ָ���������ʾ
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
            // ���� Tag ��������
            Clipboard.SetTextAsync(ClanTag.Text);
            DisplayAlert("���Ƴɹ�", $"�ѽ� {ClanTag.Text} ���Ƶ�������", "ȷ��");
        }
        else
        {
            DisplayAlert("����", "�޷���ȡ Player ����", "ȷ��");
        }

    }
    
}