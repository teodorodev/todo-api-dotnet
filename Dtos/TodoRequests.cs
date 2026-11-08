namespace TodoApi.Dtos;

public record CreateTodoRequest(string Title);

public record UpdateTodoRequest(string Title, bool IsDone);