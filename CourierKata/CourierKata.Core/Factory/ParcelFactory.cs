using CourierKata.Core.Constants;

namespace CourierKata.Core.Factory
{
    public class ParcelFactory : IParcelFactory
    {
        public Parcel CreateParcel(decimal length, decimal width, decimal height)
        {
            if (height <= 0 || length <= 0 || width <= 0)
                throw new ArgumentOutOfRangeException();

            if (height >= ParcelSizeLimit.LargeSizeLimitInCm || length >= ParcelSizeLimit.LargeSizeLimitInCm || width >= ParcelSizeLimit.LargeSizeLimitInCm)
                return new Parcel(length, width, height, ParcelSizeType.XL);

            if (height >= ParcelSizeLimit.MediumSizeLimitInCm || length >= ParcelSizeLimit.MediumSizeLimitInCm || width >= ParcelSizeLimit.MediumSizeLimitInCm)
                return new Parcel(length, width, height, ParcelSizeType.Large);

            if (height >= ParcelSizeLimit.SmallSizeLimitInCM || length >= ParcelSizeLimit.SmallSizeLimitInCM || width >= ParcelSizeLimit.SmallSizeLimitInCM)
                return new Parcel(length, width, height, ParcelSizeType.Medium);

            return new Parcel(length, width, height, ParcelSizeType.Small);
        }
    }
}
