var todoList = new List<string>();
string todoItem;
int i;
int marked = 1;
var backspacePressed = false;
var backspaceDoublePressed = false;


do
{
    Console.Clear();
    Console.WriteLine("Nedan kan du lägga till dina produkter i todo listan. Skriv 'färdig' när listan är klar.");
    Console.WriteLine();
    i = 1;
    foreach (var item in todoList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
    todoItem = Console.ReadLine()!;

    if (todoItem != "färdig")
        todoList.Add(todoItem);

} while (todoItem != "färdig");

for (i = 0; i < todoList.Count; i++)
{
    todoList[i] = " " + todoList[i];
}

while (backspaceDoublePressed == false)
{
    Console.Clear();
    Console.WriteLine("Din todo lista:");
    Console.WriteLine();
    i = 1;
    foreach (var item in todoList)
    {
        Console.WriteLine($"{item.Substring(0, 1)} {i}. {item.Substring(1)}");
        i++;
    }
    Console.WriteLine();
    Console.WriteLine("Tryck enter för att bocka av ett objekt i listan. Tryck backspace för att avsluta.");
    var keyPressed = Console.ReadKey().Key;
    if (keyPressed == ConsoleKey.Enter)
    {
        backspacePressed = false;
        while (backspacePressed == false)
        {
            Console.Clear();
            Console.WriteLine("Din todo lista:");
            Console.WriteLine();
            i = 1;
            foreach (var item in todoList)
            {
                if (i == marked)
                {
                    Console.WriteLine($"* {item.Substring(0, 1)} {i}. {item.Substring(1)}");
                }
                else
                {
                    Console.WriteLine($"  {item.Substring(0, 1)} {i}. {item.Substring(1)}");
                }

                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att bocka av ett objekt i listan. Tryck backspace för att avsluta.");

            keyPressed = Console.ReadKey().Key;

            if (keyPressed == ConsoleKey.UpArrow)
            {
                if (marked == 1)
                    marked = todoList.Count;
                else
                    marked--;
            }

            if (keyPressed == ConsoleKey.DownArrow)
            {
                if (marked == todoList.Count)
                    marked = 1;
                else
                    marked++;
            }

            if (keyPressed == ConsoleKey.Enter)
            {
                if (todoList[marked - 1].Substring(0, 1) == " ")
                    todoList[marked - 1] = "X" + todoList[marked - 1].Substring(1);
                else
                    todoList[marked - 1] = " " + todoList[marked - 1].Substring(1);
            }

            if (keyPressed == ConsoleKey.Backspace)
            {
                backspacePressed = true;
                keyPressed = ConsoleKey.None;
            }
        }
    }

    if (keyPressed == ConsoleKey.Backspace)
    {
        backspaceDoublePressed = true; 
    }
}
