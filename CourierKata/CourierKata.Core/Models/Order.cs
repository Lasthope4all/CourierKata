using CourierKata.Core.Services;

namespace CourierKata.Core.Models
{
    // Cound be a serive?
    public class Order
    {
        public Order(ICollection<Parcel> parcels, OrderType orderType = OrderType.Normal)
        {
            Type = orderType;

            var parcelPriceCalculator = new ParcelPriceCalculator();

            foreach (var p in parcels)
            {
                Items.Add(new LineItem(parcelPriceCalculator.GetParcelPrice(p.ParcelSizeType), p.ParcelSizeType.ToString()));
            }

            if (orderType == OrderType.Speedy)
                Items.Add(new LineItem(Total, Type.ToString()));
        }

        public ICollection<LineItem> Items { get; } = new List<LineItem>();

        public OrderType Type { get; }

        public decimal Total => Items.Sum(x => x.Amount);
    }
}
