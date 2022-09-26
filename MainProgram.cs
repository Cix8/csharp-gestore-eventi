public class MainProgram
{
    public static void Test()
    {
        Event pastEvent = new Event();
        Event testEvent = new Event("test evento", "26-9-2022 21:00", 50);
        Event testEvent1 = new Event("test evento 1", "26-9-2022 21:00", 150);
        Event testEvent2 = new Event("test evento 2", "27-10-2022 18:00", 100);

        EventsProgram myProgram = new EventsProgram("programma eventi");

        myProgram.AddNewEvent(pastEvent);
        myProgram.AddNewEvent(testEvent);
        myProgram.AddNewEvent(testEvent1);
        myProgram.AddNewEvent(testEvent2);

        List<Event> myEvents = myProgram.GetEventsByDate("26/9/2022");

        EventsProgram.PrintEventsBy(myEvents);

        Console.WriteLine();

        int myCount = myProgram.CountEvents();

        myProgram.PrintThisEventsList();

        myProgram.ResetEventsList();

        int myOtherCount = myProgram.CountEvents();

        testEvent.ReserveSeats(48);

        try
        {
            pastEvent.ReserveSeats(2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            testEvent.UnreserveSeats(50);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        testEvent.UnreserveSeats(48);

        Console.WriteLine(testEvent.ToString());

        Conference newConf = new Conference("title", "22-10-2022 12:00", 100, "Totonno", 13.923493);

        string price = newConf.GetFormattedPrice();
        string reducedDate = newConf.GetOnlyDate();
        string fullDateTime = newConf.GetFullDateTime();
        Console.WriteLine(newConf.ToString());
    }

    public static void Run()
    {
        EventsProgram newEventsProgram = null;

        do
        {
            Console.Write("Inserisci il titolo del programma eventi -> ");
            string programTitle = Console.ReadLine();

            try
            {
                newEventsProgram = new EventsProgram(programTitle);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } while (newEventsProgram == null);

        Console.Write("Quanti eventi vuoi inserire? -> ");
        int listLength = Convert.ToInt32(Console.ReadLine());

        while(newEventsProgram.CountEvents() < listLength)
        {
            Event newEvent = null;

            Console.WriteLine();

            Console.Write("Inserisci il titolo dell'evento -> ");
            string title = Console.ReadLine();

            Console.Write("Inserisci la data e l'ora dell'evento (gg/mm/aaaa hh:mm) -> ");
            string date = Console.ReadLine();

            Console.Write("Inserisci il numero di posti totali -> ");
            int maxCapacity = Convert.ToInt32(Console.ReadLine());

            try
            {
                newEvent = new Event(title, date, maxCapacity);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (newEvent != null) 
            {
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
                        Console.WriteLine($"Ok, ecco un riepilogo dei posti disponibili e dei posti attualmente occupati per {newEvent.Title}");
                    }

                    Console.WriteLine();

                    Console.WriteLine($"Numero di posti prenotati -> {newEvent.ReservedSeats}");
                    Console.WriteLine($"Numero di posti disponibili -> {newEvent.GetAvailableSeats()}");

                    Console.WriteLine();
                } while (answer.Contains("si"));

                newEventsProgram.AddNewEvent(newEvent);
            }
        }

        Console.WriteLine($"Il numero di eventi inseriti è pari a: {newEventsProgram.CountEvents()}");
        Console.WriteLine();
        newEventsProgram.PrintThisEventsList();
        Console.Write("Inserisci una data per sapere quali eventi ci saranno -> ");
        string thisDate = Console.ReadLine();
        List<Event> filteredEvents = newEventsProgram.GetEventsByDate(thisDate);
        Console.WriteLine();
        EventsProgram.PrintEventsBy(filteredEvents);
        Console.WriteLine();
        Console.WriteLine("Prova ad inserire anche una conferenza");
        Conference newConf = null;
        while(newConf == null)
        {
            Console.WriteLine();

            Console.Write("Inserisci il titolo della conferenza -> ");
            string title = Console.ReadLine();

            Console.Write("Inserisci la data e l'ora della conferenza (gg/mm/aaaa hh:mm) -> ");
            string date = Console.ReadLine();

            Console.Write("Inserisci il nome del relatore -> ");
            string speaker = Console.ReadLine();

            Console.Write("Inserisci il prezzo del biglietto -> ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Inserisci il numero di posti totali -> ");
            int maxCapacity = Convert.ToInt32(Console.ReadLine());

            try
            {
                newConf = new Conference(title, date, maxCapacity, speaker, price);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Console.Write("Quanti posti desideri prenotare? -> ");
        int confReservedSeats = Convert.ToInt32(Console.ReadLine());
        newConf.ReserveSeats(confReservedSeats);

        Console.WriteLine();

        Console.WriteLine($"Numero di posti prenotati -> {newConf.ReservedSeats}");
        Console.WriteLine($"Numero di posti disponibili -> {newConf.GetAvailableSeats()}");

        string anotherAnswer;

        do
        {
            Console.WriteLine();

            Console.Write("Vuoi disdire dei posti (si/no)? -> ");
            anotherAnswer = Console.ReadLine().Trim().ToLower();
            if (anotherAnswer.Contains("si"))
            {
                Console.Write("Ok, inserisci il numero di posti che intendi disdire -> ");
                int seatsToUnreserve = Convert.ToInt32(Console.ReadLine());
                newConf.UnreserveSeats(seatsToUnreserve);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Ok, ecco un riepilogo dei posti disponibili e dei posti attualmente occupati per {newConf.Title}");
            }

            Console.WriteLine();

            Console.WriteLine($"Numero di posti prenotati -> {newConf.ReservedSeats}");
            Console.WriteLine($"Numero di posti disponibili -> {newConf.GetAvailableSeats()}");

            Console.WriteLine();
        } while (anotherAnswer.Contains("si"));
        newEventsProgram.AddNewEvent(newConf);
        newEventsProgram.PrintThisEventsList();
    }
}