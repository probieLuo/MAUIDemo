using System.Collections.Concurrent;

namespace CocQuery.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("提示", "是否删除缓存", "Yes", "No");
        if (!answer)
            return;
        // 获取目标目录路径
        string cacheDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"cache");

        // 检查目录是否存在
        if (Directory.Exists(cacheDirectory))
        {
            try
            {
                // 获取目录下的所有文件和文件夹
                string[] files = Directory.GetFiles(cacheDirectory, "*.*", SearchOption.AllDirectories);
                string[] directories = Directory.GetDirectories(cacheDirectory, "*.*", SearchOption.AllDirectories);

                // 使用并发队列来存储需要删除的文件和文件夹
                ConcurrentBag<string> itemsToDelete = new ConcurrentBag<string>();

                // 添加文件到并发队列
                Parallel.ForEach(files, file =>
                {
                    itemsToDelete.Add(file);
                });

                // 添加文件夹到并发队列
                Parallel.ForEach(directories, directory =>
                {
                    itemsToDelete.Add(directory);
                });

                // 删除文件和文件夹
                Parallel.ForEach(itemsToDelete, item =>
                {
                    try
                    {
                        if (File.Exists(item))
                        {
                            File.Delete(item);
                        }
                        else if (Directory.Exists(item))
                        {
                            Directory.Delete(item, true); // 递归删除文件夹
                        }
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        throw ex;
#endif
                    }
                });
                DisplayAlert("提示", "清除成功", "OK");
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }
        }
    }
}