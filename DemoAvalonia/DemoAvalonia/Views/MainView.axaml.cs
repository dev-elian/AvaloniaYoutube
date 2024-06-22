using Avalonia.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Avalonia.Threading;
using Avalonia.Media;
namespace DemoAvalonia.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }


    void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Dispatcher.UIThread.Invoke(async () => {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
                if (response.IsSuccessStatusCode)
                {
                    tbText.Foreground = new SolidColorBrush(Color.FromRgb(0,255,0));
                    tbText.Text = await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException e)
            {
                tbText.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                tbText.Text = $"Request error: {e.Message}";
            }
            catch (Exception e)
            {
                tbText.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                tbText.Text = $"Error: {e.Message}";
            }
        });
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Dispatcher.UIThread.Invoke(async () => {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("http://md5.jsontest.com/?text=hola");
                if (response.IsSuccessStatusCode)
                {
                    tbText.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    tbText.Text = await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException e)
            {
                tbText.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                tbText.Text = $"Request error: {e.Message}";
            }
            catch (Exception e)
            {
                tbText.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                tbText.Text = $"Error: {e.Message}";
            }
        });
    }
}
