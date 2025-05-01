namespace TakuMaui.Models;

public class ImageItem : MediaItem
{
    public required int Width { get; set; }
    public required int Height { get; set; }
    public string Author { get; set; } = string.Empty;
    public DateTime CaptureDate { get; set; } = DateTime.Now;
    public int Likes { get; set; }
}