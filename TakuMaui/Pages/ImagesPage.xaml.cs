using TakuMaui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core.Primitives;

namespace TakuMaui.Pages;

public partial class ImagesPage : ContentPage, INotifyPropertyChanged
{
    private ObservableCollection<MediaItem> _mediaItems = new();

    public ObservableCollection<MediaItem> MediaItems
    {
        get => _mediaItems;
        set
        {
            _mediaItems = value;
            RaisePropertyChanged();
        }
    }

    public ImagesPage()
    {
        InitializeComponent();
        BindingContext = this;
        LoadMedia();
    }

    private void LoadMedia()
    {
        MediaItems.Clear();

        var sampleImages = new[] 
        { 
            ("dante.jpg", "Dante", "Image of Dante"),
            ("itachi.jpg", "Itachi", "Image of Itachi"),
            ("luffy.jpg", "Luffy", "Image of Luffy")
        };

        // Add all images first
        for (int i = 0; i < sampleImages.Length; i++)
        {
            MediaItems.Add(new MediaItem
            {
                Title = sampleImages[i].Item2,
                Description = sampleImages[i].Item3,
                FilePath = sampleImages[i].Item1,
                Type = MediaType.Image,
                Rating = Random.Shared.NextDouble() * 5,
                Width = 1080,
                Height = 1920,
                Author = $"Photographer {i + 1}",
                CaptureDate = DateTime.Now.AddDays(-Random.Shared.Next(1, 365)),
                Likes = Random.Shared.Next(100, 10000)
            });
        }

        // Add video at the end
        var videoItem = new MediaItem
        {
            Title = "Sample Video",
            Description = "A cool sample video",
            FilePath = "android.resource://com.companyname.takumaui/raw/video",
            Type = MediaType.Video,
            Author = "Videographer",
            CaptureDate = DateTime.Now.AddDays(-Random.Shared.Next(1, 30)),
            Likes = Random.Shared.Next(50, 5000)
        };

        MediaItems.Add(videoItem);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private void OnMediaElementLoaded(object sender, EventArgs e)
    {
        if (sender is MediaElement mediaElement)
        {
            try
            {
                mediaElement.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error playing video: {ex.Message}");
            }
        }
    }

    private void OnMediaFailed(object sender, MediaFailedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"Media failed to load: {e.ErrorMessage}");
    }

    private void OnMediaOpened(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Media opened successfully");
        if (sender is MediaElement mediaElement)
        {
            mediaElement.Play();
        }
    }

    private void OnMediaElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (sender is MediaElement mediaElement && e.PropertyName == "IsVisible")
        {
            if (!mediaElement.IsVisible && mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Pause();
            }
            else if (mediaElement.IsVisible && mediaElement.CurrentState == MediaElementState.Paused)
            {
                mediaElement.Play();
            }
        }
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    private void RaisePropertyChanged([CallerMemberName] string? propertyName = default)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}