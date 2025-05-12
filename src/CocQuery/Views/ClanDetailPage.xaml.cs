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

}