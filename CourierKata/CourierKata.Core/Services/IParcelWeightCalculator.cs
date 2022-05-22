namespace CourierKata.Core.Services
{
    public interface IParcelWeightCalculator
    {
        public decimal CalculateOverWeightOfParcel(ParcelSizeType parcelSizeType, decimal weight);
    }
}
