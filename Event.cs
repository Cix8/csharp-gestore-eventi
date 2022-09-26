public class Event
{
    private string title;
    private DateTime date;
    private int maxCapacity;
    public int ReservedSeats { get; private set; }

    public Event()
    {
        this.title = "evento passato";
        this.date = DateTime.Parse("22-09-2022 15:00");
        this.maxCapacity = 30;
        this.ReservedSeats = 0;
    }

    public Event(string _title, string _date, int _maxCapacity)
    {
        this.Title = _title;
        this.Date = DateTime.Parse(_date);
        this.MaxCapacity = _maxCapacity;
        this.ReservedSeats = 0;
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
                throw new Exception("Non è possibile salvare un evento senza titolo");
            }
        }
    }

    public DateTime Date
    {
        get
        {
            return this.date;
        }
        set
        {
            DateTime currentData = DateTime.Now;
            DateTime eventData = value;
            int result = DateTime.Compare(eventData, currentData);
            if (result >= 0)
            {
                this.date = value;
            }
            else
            {
                throw new Exception("Data inserita non valida");
            }
        }
    }

    public int MaxCapacity
    {
        get
        {
            return this.maxCapacity;
        }
        private set
        {
            if (value > 0)
            {
                this.maxCapacity = value;
            }
            else
            {
                throw new Exception("La capacità massima non può essere negativa o uguale a zero");
            }
        }
    }

    public void ReserveSeats(int seats)
    {
        DateTime currentData = DateTime.Now;
        DateTime eventData = this.Date;
        int result = DateTime.Compare(eventData, currentData);
        if (result < 0)
        {
            throw new Exception($"L'evento si è già tenuto in data {DateOnly.FromDateTime(this.Date)} alle ore {TimeOnly.FromDateTime(this.Date)}");
        }
        else if(this.MaxCapacity - this.ReservedSeats - seats >= 0)
        {
            this.ReservedSeats += seats;
        } else
        {
            throw new Exception("Non posso prenotare il numero di posti inserito perchè supererebbe la capacità massima");
        }
    }

    public void UnreserveSeats(int seats)
    {
        DateTime currentData = DateTime.Now;
        DateTime eventData = this.Date;
        int result = DateTime.Compare(eventData, currentData);
        if (result < 0)
        {
            throw new Exception($"L'evento si è già tenuto in data {DateOnly.FromDateTime(this.Date)} alle ore {TimeOnly.FromDateTime(this.Date)}");
        }
        else if (this.ReservedSeats - seats >= 0)
        {
            this.ReservedSeats -= seats;
        }
        else
        {
            throw new Exception("I posti attualmente occupati sono inferiori al numero di prenotazioni che si intende disdire");
        }
    }

    public override string ToString()
    {
        return $"{this.Date.ToString("dd/MM/yyyy")} - {this.Title}";
    }

    public int GetAvailableSeats()
    {
        return this.MaxCapacity - this.ReservedSeats;
    }

}
