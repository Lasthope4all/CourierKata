namespace CourierKata.Core.Models
{
    public class LineItem
    {
        public LineItem(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
        }

        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}