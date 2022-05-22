using CourierKata.Core.Constants;


namespace CourierKata.Core.Services
{
    public class ParcelPriceCalculator : IParcelPriceCalculator
    {
        public decimal GetParcelPrice(ParcelSizeType parcelSizeType)
        {
            return parcelSizeType switch
            {
                ParcelSizeType.Small => ParcelPricing.SmallSizePrice,
                ParcelSizeType.Medium => ParcelPricing.MediumSizePrice,
                ParcelSizeType.Large => ParcelPricing.LargeSizePrice,
                ParcelSizeType.XL => ParcelPricing.XLSizePrice,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
