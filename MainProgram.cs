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
        int listLength = 0;
        try
        {
            listLength = Convert.ToInt32(Console.ReadLine());
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        while(newEventsProgram.CountEvents() < listLength)
        {
            Event newEvent = MainProgram.Builder();

            if (newEvent != null) 
            {
                MainProgram.SeatsReserver(newEvent);

                MainProgram.SeatsUnreserver(newEvent);

                newEventsProgram.AddNewEvent(newEvent);
            }
        }

        Console.WriteLine($"Il numero di eventi inseriti è pari a: {newEventsProgram.CountEvents()}");
        Console.WriteLine();
        newEventsProgram.PrintThisEventsList();
        Console.Write("Inserisci una data per sapere quali eventi ci saranno -> ");
        string thisDate = Console.ReadLine();
        List<Event> filteredEvents = new List<Event>();
        try
        {
            filteredEvents = newEventsProgram.GetEventsByDate(thisDate);
            Console.WriteLine();
            EventsProgram.PrintEventsBy(filteredEvents);
            Console.WriteLine();
        } catch (Exception e)
        {
            Console.WriteLine();
            Console.WriteLine(e.Message);
            Console.WriteLine();
        }
        Console.WriteLine("Prova ad inserire anche una conferenza");
        //newEventsProgram.ResetEventsList();
        Conference newConf = (Conference)MainProgram.Builder("conference");
        while(newConf == null)
        {
            newConf = (Conference)MainProgram.Builder("conference");
        }

        MainProgram.SeatsReserver(newConf);

        MainProgram.SeatsUnreserver(newConf);

        newEventsProgram.AddNewEvent(newConf);
        newEventsProgram.PrintThisEventsList();
    }

    public static Event Builder(string type = "event")
    {
        Event newEvent = null;

        Console.WriteLine();

        Console.Write("Inserisci il titolo dell'evento -> ");
        string title = Console.ReadLine();

        Console.Write("Inserisci la data e l'ora dell'evento (gg/mm/aaaa hh:mm) -> ");
        string date = Console.ReadLine();

        string speaker = "";
        double price = -1;

        if(type == "conference")
        {
            Console.Write("Inserisci il nome del relatore -> ");
            speaker = Console.ReadLine();

            Console.Write("Inserisci il prezzo del biglietto -> ");
            try
            {
                price = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.Write("Inserisci il numero di posti totali -> ");
        int maxCapacity = -1;
        try
        {
            maxCapacity = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        if (type == "conference")
        {
            try
            {
                newEvent = new Conference(title, date, maxCapacity, speaker, price);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } else
        {
            try
            {
                newEvent = new Event(title, date, maxCapacity);
            }
            catch (Exception e)
            {
                newEvent = null;
                Console.WriteLine(e.Message);
            }
        }
        return newEvent;
    }

    public static void SeatsReserver(Event thisEvent)
    {
        Console.Write("Quanti posti desideri prenotare? -> ");
        int reservedSeats = -1;
        try
        {
            reservedSeats = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            thisEvent.ReserveSeats(reservedSeats);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine();

        Console.WriteLine($"Numero di posti prenotati -> {thisEvent.ReservedSeats}");
        Console.WriteLine($"Numero di posti disponibili -> {thisEvent.GetAvailableSeats()}");
    }

    public static void SeatsUnreserver(Event thisEvent)
    {
        string answer;

        do
        {
            Console.WriteLine();

            Console.Write("Vuoi disdire dei posti (si/no)? -> ");
            answer = Console.ReadLine().Trim().ToLower();
            if (answer.Contains("si"))
            {
                Console.Write("Ok, inserisci il numero di posti che intendi disdire -> ");
                int seatsToUnreserve = -1;
                try
                {
                    seatsToUnreserve = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    thisEvent.UnreserveSeats(seatsToUnreserve);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Ok, ecco un riepilogo dei posti disponibili e dei posti attualmente occupati per {thisEvent.Title}");
            }

            Console.WriteLine();

            Console.WriteLine($"Numero di posti prenotati -> {thisEvent.ReservedSeats}");
            Console.WriteLine($"Numero di posti disponibili -> {thisEvent.GetAvailableSeats()}");

            Console.WriteLine();
        } while (answer.Contains("si"));
    }
}