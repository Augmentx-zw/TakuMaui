using TakuMaui.Models;
using System.Collections.ObjectModel;

namespace TakuMaui.Pages;

public partial class TablesPage : ContentPage
{
    private readonly List<TaskItem> _allTasks = new();
    private readonly List<TaskItem> _filteredTasks = new();
    public ObservableCollection<TaskItem> DisplayedTasks { get; private set; } = new();
    
    private int _itemsPerPage = 5;
    private int _currentPage = 1;
    private int _totalPages = 1;
    private string _currentSearchText = "";

    public TablesPage()
    {
        InitializeComponent();
        InitializeTasks();
        BindingContext = this;
        UpdateDisplayedTasks();
    }

    private void InitializeTasks()
    {
        _allTasks.AddRange(new List<TaskItem>
        {
            new TaskItem { TaskName = "Setup MVVM", Category = "Architecture", Status = "Completed", CompletionRate = "100%" },
            new TaskItem { TaskName = "Shell Navigation", Category = "Navigation", Status = "Completed", CompletionRate = "100%" },
            new TaskItem { TaskName = "Design UI", Category = "UI/UX", Status = "In Progress", CompletionRate = "75%" },
            new TaskItem { TaskName = "Add Database", Category = "Data", Status = "In Progress", CompletionRate = "60%" },
            new TaskItem { TaskName = "Implement Auth", Category = "Security", Status = "Not Started", CompletionRate = "0%" },
            new TaskItem { TaskName = "Create Controls", Category = "UI/UX", Status = "In Progress", CompletionRate = "40%" },
            new TaskItem { TaskName = "Push Notifications", Category = "Features", Status = "Not Started", CompletionRate = "0%" },
            new TaskItem { TaskName = "Offline Mode", Category = "Data", Status = "Not Started", CompletionRate = "0%" },
            new TaskItem { TaskName = "Add Analytics", Category = "Monitoring", Status = "Not Started", CompletionRate = "0%" },
            new TaskItem { TaskName = "Create Unit Tests", Category = "Testing", Status = "In Progress", CompletionRate = "30%" },
            new TaskItem { TaskName = "Optimize Performance", Category = "Performance", Status = "Not Started", CompletionRate = "0%" },
            new TaskItem { TaskName = "File Handling", Category = "Features", Status = "In Progress", CompletionRate = "50%" }
        });
        
        _filteredTasks.AddRange(_allTasks);
    }

    private void UpdateDisplayedTasks()
    {
        var startIndex = (_currentPage - 1) * _itemsPerPage;
        var pageItems = _filteredTasks.Skip(startIndex).Take(_itemsPerPage);
        
        DisplayedTasks.Clear();
        foreach (var item in pageItems)
        {
            DisplayedTasks.Add(item);
        }

        _totalPages = (_filteredTasks.Count + _itemsPerPage - 1) / _itemsPerPage;
        UpdatePaginationControls();
    }

    private void UpdatePaginationControls()
    {
        PageInfo.Text = $"Page {_currentPage} of {_totalPages}";
        PreviousButton.IsEnabled = _currentPage > 1;
        NextButton.IsEnabled = _currentPage < _totalPages;
    }

    private void OnPreviousClicked(object sender, EventArgs e)
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            UpdateDisplayedTasks();
        }
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        if (_currentPage < _totalPages)
        {
            _currentPage++;
            UpdateDisplayedTasks();
        }
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        _currentSearchText = e.NewTextValue?.ToLower() ?? "";
        _currentPage = 1;  // Reset to first page when searching
        
        _filteredTasks.Clear();
        _filteredTasks.AddRange(_allTasks
            .Where(t => t.TaskName.ToLower().Contains(_currentSearchText) ||
                       t.Category.ToLower().Contains(_currentSearchText) ||
                       t.Status.ToLower().Contains(_currentSearchText)));
        
        UpdateDisplayedTasks();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}