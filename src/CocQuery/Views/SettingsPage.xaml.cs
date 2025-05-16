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
        bool answer = await DisplayAlert("��ʾ", "�Ƿ�ɾ������", "Yes", "No");
        if (!answer)
            return;
        // ��ȡĿ��Ŀ¼·��
        string cacheDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"cache");

        // ���Ŀ¼�Ƿ����
        if (Directory.Exists(cacheDirectory))
        {
            try
            {
                // ��ȡĿ¼�µ������ļ����ļ���
                string[] files = Directory.GetFiles(cacheDirectory, "*.*", SearchOption.AllDirectories);
                string[] directories = Directory.GetDirectories(cacheDirectory, "*.*", SearchOption.AllDirectories);

                // ʹ�ò����������洢��Ҫɾ�����ļ����ļ���
                ConcurrentBag<string> itemsToDelete = new ConcurrentBag<string>();

                // ����ļ�����������
                Parallel.ForEach(files, file =>
                {
                    itemsToDelete.Add(file);
                });

                // ����ļ��е���������
                Parallel.ForEach(directories, directory =>
                {
                    itemsToDelete.Add(directory);
                });

                // ɾ���ļ����ļ���
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
                            Directory.Delete(item, true); // �ݹ�ɾ���ļ���
                        }
                    }
                    catch (Exception ex)
                    {
#if DEBUG
                        throw ex;
#endif
                    }
                });
                DisplayAlert("��ʾ", "����ɹ�", "OK");
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