var shoppingList = new List<string>();
string shoppingItem;
Console.WriteLine("Nedan kan du lägga till dina produkter i shoppinglistan. Skriv 'exit' när listan är färdig.");
do
{
    Console.Clear();
    Console.WriteLine("Nedan kan du lägga till dina produkter i shoppinglistan. Skriv 'exit' när listan är färdig.");
    shoppingList.ForEach(Console.WriteLine);
    shoppingItem = Console.ReadLine()!;

    if(shoppingItem != "exit")
        shoppingList.Add(shoppingItem);

} while (shoppingItem != "exit");

Console.Clear();
Console.WriteLine("Din shoppinglista:");
shoppingList.ForEach(Console.WriteLine);
Console.ReadKey();