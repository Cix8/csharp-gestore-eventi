using System.Runtime.CompilerServices;

Event pastEvent = new Event();
Event testEvent = new Event("test evento", "26-9-2022 12:00", 50);

testEvent.ReserveSeats(48);

try
{
    pastEvent.ReserveSeats(2);
} catch(Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    testEvent.UnreserveSeats(50);
} catch(Exception e)
{
    Console.WriteLine(e.Message);
}

testEvent.UnreserveSeats(48);

Console.WriteLine(testEvent.ToString());

Console.WriteLine();

Console.Write("Inserisci il titolo dell'evento -> ");
string title = Console.ReadLine();

Console.Write("Inserisci la data e l'ora dell'evento (gg/mm/aaaa hh:mm) -> ");
string date = Console.ReadLine();

Console.Write("Inserisci il numero di posti totali -> ");
int maxCapacity = Convert.ToInt32(Console.ReadLine());

Event newEvent = new Event(title, date, maxCapacity);

Console.Write("Quanti posti desideri prenotare? -> ");
int reservedSeats = Convert.ToInt32(Console.ReadLine());
newEvent.ReserveSeats(reservedSeats);

Console.WriteLine();

Console.WriteLine($"Numero di posti prenotati -> {newEvent.ReservedSeats}");
Console.WriteLine($"Numero di posti disponibili -> {newEvent.GetAvailableSeats()}");

string answer;

do
{
    Console.WriteLine();

    Console.Write("Vuoi disdire dei posti (si/no)? -> ");
    answer = Console.ReadLine().Trim().ToLower();
    if (answer.Contains("si"))
    {
        Console.Write("Ok, inserisci il numero di posti che intendi disdire -> ");
        int seatsToUnreserve = Convert.ToInt32(Console.ReadLine());
        newEvent.UnreserveSeats(seatsToUnreserve);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Ok, ecco un riepilogo dei posti disponibili e dei posti attualmente occupati");
    }

    Console.WriteLine();

    Console.WriteLine($"Numero di posti prenotati -> {newEvent.ReservedSeats}");
    Console.WriteLine($"Numero di posti disponibili -> {newEvent.GetAvailableSeats()}");

    Console.WriteLine();
} while (answer.Contains("si"));