using TakuMaui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TakuMaui.Pages;

public partial class ImagesPage : ContentPage, INotifyPropertyChanged
{
    private ObservableCollection<ImageItem> _images = new();

    public ObservableCollection<ImageItem> Images
    {
        get => _images;
        set
        {
            _images = value;
            RaisePropertyChanged();
        }
    }

    public ImagesPage()
    {
        InitializeComponent();
        BindingContext = this;
        LoadImages();
    }

    private void LoadImages()
    {
        var sampleImages = new[] 
        { 
            "dante.jpg",
            "itachi.jpg",
            "luffy.jpg"
        };

        for (int i = 0; i < sampleImages.Length; i++)
        {
            Images.Add(new ImageItem
            {
                Title = $"Sample Image {i + 1}",
                Description = $"A beautiful sample image {i + 1}",
                FilePath = sampleImages[i],
                Rating = Random.Shared.NextDouble() * 5,
                Width = 1080,
                Height = 1920,
                Author = $"Photographer {i + 1}",
                CaptureDate = DateTime.Now.AddDays(-Random.Shared.Next(1, 365)),
                Likes = Random.Shared.Next(100, 10000)
            });
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    private void RaisePropertyChanged([CallerMemberName] string? propertyName = default)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}