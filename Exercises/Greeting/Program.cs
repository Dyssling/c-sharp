Console.Write("Vänligen ange ditt förnamn: ");
string firstName = Console.ReadLine()!;

Console.Write($"Hej {firstName}! Vänligen ange ditt efternamn: ");
string lastName = Console.ReadLine()!;

Console.Write($"{firstName} {lastName} vänligen ange din ålder: ");
int.TryParse(Console.ReadLine()!, out int age);
int birthYear = 2023 - age;

Console.Write($"Ditt födelseår är alltså {birthYear}. Vänligen ange din stad: ");
string city = Console.ReadLine()!;

if (city != "")
{
    city = city.Substring(0, 1).ToUpper() + city.Substring(1);
}


Console.WriteLine("Sammanfattning:");
Console.Write($"Ditt namn är {firstName} {lastName} och du föddes år {birthYear}, och du bor i {city}.");
Console.ReadKey();