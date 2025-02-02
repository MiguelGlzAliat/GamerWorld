using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;

namespace GamerWorld.Views
{
    public partial class Section4 : ContentPage
    {
        public Section4()
        {
            InitializeComponent();

            // Cargar el archivo HTML desde Resources/Raw
            LoadHtml();
        }

        private async void LoadHtml()
        {
            try
            {
                string fileName = "google_maps.html";
                string localPath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                if (!File.Exists(localPath))
                {
                    using var stream = await FileSystem.OpenAppPackageFileAsync($"Raw/{fileName}");
                    using var reader = new StreamReader(stream);
                    string htmlContent = await reader.ReadToEndAsync();
                    File.WriteAllText(localPath, htmlContent);
                }

                mapWebView.Source = new UrlWebViewSource { Url = localPath };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el archivo HTML: {ex.Message}");
                errorLabel.IsVisible = true;
            }
        }


        private void OnWebNavigating(object sender, WebNavigatingEventArgs e)
        {
            loadingSpinner.IsRunning = true;
            loadingSpinner.IsVisible = true;
            errorLabel.IsVisible = false;
        }

        private void OnWebNavigated(object sender, WebNavigatedEventArgs e)
        {
            loadingSpinner.IsRunning = false;
            loadingSpinner.IsVisible = false;

            if (e.Result != WebNavigationResult.Success)
            {
                errorLabel.IsVisible = true;
            }
        }
    }
}
