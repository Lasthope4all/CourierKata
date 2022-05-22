using System.Collections;
using System.Collections.Generic;

namespace CourierKata.Tests
{
    public abstract class BaseTest
    {
        public const decimal SmallSizePrice = 3;
        public const decimal MediumSizePrice = 8;
        public const decimal LargeSizePrice = 15;
        public const decimal XLSizePrice = 25;

        public const decimal GenericOrderPartialListPrice = SmallSizePrice + MediumSizePrice + LargeSizePrice + XLSizePrice;

        public const int GenericOrderPartialListCount = 4;
        public const int GenericOrderPartialListCountSpeedy = 5;
        public const decimal OrderPriceMultipliersSpeedy = 2;
        public const decimal SmallSizePriceSpeedy = SmallSizePrice * OrderPriceMultipliersSpeedy;
        public const decimal GenericOrderPartialListPriceSpeedy = GenericOrderPartialListPrice * OrderPriceMultipliersSpeedy;


        public static Parcel SmallPartial() => new Parcel(1, 1, 1, ParcelSizeType.Small);
        public static Parcel MidPartial() => new Parcel(10, 10, 10, ParcelSizeType.Medium);
        public static Parcel LargePartial() => new Parcel(50, 50, 50, ParcelSizeType.Large);
        public static Parcel XLPartial() => new Parcel(100, 100, 100, ParcelSizeType.XL);

        public static List<Parcel> GenericOrderPartialList() => new List<Parcel> { SmallPartial(), MidPartial(), LargePartial(), XLPartial() };
    }
}
