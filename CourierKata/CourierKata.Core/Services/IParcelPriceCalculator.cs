namespace CourierKata.Core.Services
{
    public interface IParcelPriceCalculator
    {
        public decimal GetParcelPrice(ParcelSizeType parcelSizeType);
    }
}
