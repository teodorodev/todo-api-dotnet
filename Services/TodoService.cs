using TodoApi.Models;

namespace TodoApi.Services;

public class TodoService
{
    private readonly List<TodoItem> _items = new();
    private readonly object _lock = new();
    private long _nextId = 1;

    public List<TodoItem> GetAll()
    {
        lock (_lock)
        {
            return _items.ToList();
        }
    }

    public TodoItem? GetById(long id)
    {
        lock (_lock)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }
    }

    public TodoItem Add(string title)
    {
        lock (_lock)
        {
            var newItem = new TodoItem
            {
                Id = _nextId++,
                Title = title
            };
            _items.Add(newItem);
            return newItem;
        }
    }

    public TodoItem? Update(long id, string title, bool isDone)
    {
        lock (_lock)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return null;
            }
            item.Title = title;
            item.IsDone = isDone;
            return item;
        }
    }

    public bool Delete(long id)
    {
        lock (_lock)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }
    }

}
