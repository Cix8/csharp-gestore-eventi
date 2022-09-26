public class Conference : Event
{
    private string speaker;
    private double price;

    public Conference(string _title, string _date, int _maxCapacity, string _speaker, double _price) : base(_title, _date, _maxCapacity)
    {
        this.Speaker = _speaker;
        this.Price = _price;
    }

    public string Speaker
    {
        get
        {
            return this.speaker;
        }
        private set
        {
            if (value.Trim().Length != 0)
            {
                this.speaker = value;
            }
            else
            {
                throw new Exception("Il relatore non è stato specificato");
            }
        }
    }

    public double Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value >= 0)
            {
                this.price = value;
            }
            else
            {
                throw new Exception("Il prezzo non può essere negativo");
            }
        }
    }

    public string GetFormattedPrice()
    {
        return $"{this.price.ToString("0.00")} euro";
    }

    public string GetOnlyDate()
    {
        return DateOnly.FromDateTime(this.Date).ToString();
    }

    public string GetFullDateTime()
    {
        return this.Date.ToString();
    }

    public override string ToString()
    {
        return $"{this.GetOnlyDate()} - {this.Title} - {this.Speaker} - {this.GetFormattedPrice()}";
    }
}