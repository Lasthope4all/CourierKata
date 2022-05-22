using CourierKata.Core.Constants;

namespace CourierKata.Core.Services
{
    public class ParcelWeightCalculator : IParcelWeightCalculator
    {
        public decimal CalculateOverWeightOfParcel(ParcelSizeType parcelSizeType, decimal weight)
        {
            decimal overWeightByKG = parcelSizeType switch
            {
                ParcelSizeType.Small => weight - ParcelWeightLimit.SmallSizeWeightLimitInKG,
                ParcelSizeType.Medium => weight - ParcelWeightLimit.MediumSizeWeightLimitInKG,
                ParcelSizeType.Large => weight - ParcelWeightLimit.LargeSizeWeightLimitInKG,
                ParcelSizeType.XL => weight - ParcelWeightLimit.XLSizeWeightLimitInKG,
                _ => throw new ArgumentOutOfRangeException(),
            };

            return overWeightByKG < 0 ? 0 : overWeightByKG;
        }
    }
}
