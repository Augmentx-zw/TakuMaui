namespace TakuMaui.Models;

public class MediaItem
{
    public required string Title { get; set; }
    public required string FilePath { get; set; }
    public required double Rating { get; set; }
    public string Description { get; set; } = string.Empty;
}