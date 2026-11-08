namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }

}
