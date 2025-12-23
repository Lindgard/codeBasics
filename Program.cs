using System.IO;
using System.Text.Json;

var jsonString = File.ReadAllText("todos.json");
Console.WriteLine(jsonString);

class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool Completed { get; set; }
}