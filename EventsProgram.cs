public class EventsProgram
{
    private string title;

    private List<Event> eventsList;

    public EventsProgram(string _title)
    {
        this.Title = _title;
        this.eventsList = new List<Event>();
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if (value.Trim().Length != 0)
            {
                this.title = value.Trim();
            }
            else
            {
                throw new Exception("Non è possibile salvare un programma di eventi senza titolo");
            }
        }
    }

    public void AddNewEvent(Event newEvent)
    {
        this.eventsList.Add(newEvent);
    }

    public List<Event> GetEventsByDate(string date)
    {
        DateOnly formattedDate = DateOnly.FromDateTime(DateTime.Parse(date));
        List<Event> events = new List<Event>();
        foreach(Event singelEvent in this.eventsList)
        {
            DateOnly dateOnlyEvent = DateOnly.FromDateTime(singelEvent.Date);
            if(dateOnlyEvent.Equals(formattedDate))
            {
                events.Add(singelEvent);
            }
        }
        return events;
    }

    public static void PrintEventsBy(List<Event> thisEventsList)
    {
        Console.WriteLine("Ecco la tua lista eventi:");
        Console.WriteLine();
        foreach(Event singleEvent in thisEventsList)
        {
            Console.WriteLine(singleEvent.ToString());
        }
    }

    public void PrintThisEventsList()
    {
        Console.WriteLine($"Tutti gli eventi di {this.Title}:");
        Console.WriteLine();
        foreach (Event singleEvent in this.eventsList)
        {
            Console.WriteLine(singleEvent.ToString());
        }
    }

    public int CountEvents()
    {
        return this.eventsList.Count;
    }

    public void ResetEventsList()
    {
        this.eventsList = new List<Event>();
    }
}