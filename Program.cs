using System.IO;
using System.Text.Json;

//* hente inn json til programmet fra json fil
var jsonString = File.ReadAllText("todos.json");

//* JSON parses til en liste med Todos, case-sensitive matching trengs fordi JSON er camelCase
var todos = JsonSerializer.Deserialize<List<Todo>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//* null guard
if (todos == null)
{
    throw new Exception("could not parse JSON");
}

//* Where filtrerer todos basert på completion state. LINQ-operator, Select er en
//* Annen LINQ-operator som er veldig vanlig å bruke til å transformere element.
var completedTask = todos.Where(todo => todo.Completed == true);
var unfinishedTask = todos.Where(todo => todo.Completed == false);

//* OrderBy er fra LINQ og lar oss sortere basert på det vi passer inn med arrow-function i parantesen
var sorted = todos.OrderBy(todo => todo.Completed);

//* Loop gjennom hvert objekt basert på sorted over og print ut med Console.WriteLine.
//* Bruker da keys fra klassen under til å hente riktig informasjon fra filen
foreach (var todo in sorted)
{
    Console.WriteLine(todo.UserId);
    Console.WriteLine(todo.Id);
    Console.WriteLine(todo.Title);
    Console.WriteLine(todo.Completed);
}

//* Klasse som representerer todo items fra JSON payload(data fra filen)
class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool Completed { get; set; }
}