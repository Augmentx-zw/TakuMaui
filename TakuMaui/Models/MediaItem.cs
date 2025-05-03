namespace TakuMaui.Models;

public enum MediaType
{
    Image,
    Video
}

public class MediaItem
{
    public required string Title { get; set; }
    public required string FilePath { get; set; }
    public required MediaType Type { get; set; } // Added to distinguish between image and video
    public double Rating { get; set; } // Made nullable or provide default
    public string Description { get; set; } = string.Empty;
    public int Width { get; set; } // Added from ImageItem
    public int Height { get; set; } // Added from ImageItem
    public string Author { get; set; } = string.Empty; // Added from ImageItem
    public DateTime CaptureDate { get; set; } // Added from ImageItem
    public int Likes { get; set; } // Added from ImageItem
}