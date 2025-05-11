namespace CocQuery.Views;

public partial class ClanSearchPage : ContentPage
{
    public ClanSearchPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // 显示加载动画
        activityIndicator.IsRunning = true;
        activityIndicator.IsVisible = true;

        // 模拟耗时操作
        await Task.Delay(3000); // 模拟耗时操作，例如网络请求

        // 隐藏加载动画
        activityIndicator.IsRunning = false;
        activityIndicator.IsVisible = false;

    }
}