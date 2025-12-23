using System.IO;
using System.Text.Json;

//* hente inn json til programmet fra json fil
var jsonString = File.ReadAllText("todos.json");

//* 
var todos = JsonSerializer.Deserialize<List<Todo>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//* null guard
if (todos == null)
{
    throw new Exception("could not parse JSON");
}

var completedTask = todos.Where(todo => todo.Completed == true);
var unfinishedTask = todos.Where(todo => todo.Completed == false);

var sorted = todos.OrderBy(todo => todo.Completed);

foreach (var todo in sorted)
{
    Console.WriteLine(todo.UserId);
    Console.WriteLine(todo.Id);
    Console.WriteLine(todo.Title);
    Console.WriteLine(todo.Completed);
}
class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool Completed { get; set; }
}