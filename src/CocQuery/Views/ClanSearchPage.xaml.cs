namespace CocQuery.Views;

public partial class ClanSearchPage : ContentPage
{
    public ClanSearchPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // ��ʾ���ض���
        activityIndicator.IsRunning = true;
        activityIndicator.IsVisible = true;

        // ģ���ʱ����
        await Task.Delay(3000); // ģ���ʱ������������������

        // ���ؼ��ض���
        activityIndicator.IsRunning = false;
        activityIndicator.IsVisible = false;

    }
}