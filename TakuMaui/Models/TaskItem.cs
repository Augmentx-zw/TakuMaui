using Microsoft.Maui.Graphics;

namespace TakuMaui.Models;

public class TaskItem
{
    public required string TaskName { get; set; }
    public required string Category { get; set; }
    public required string Status { get; set; }
    public required string CompletionRate { get; set; }
    public Color StatusColor
    {
        get
        {
            return Status switch
            {
                "Completed" => Colors.Green,
                "In Progress" => Colors.Orange,
                "Not Started" => Colors.Red,
                _ => Colors.Gray
            };
        }
    }
}