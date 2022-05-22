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

        public const int SmallSizeWeightLimitInKG = 1;
        public const int MediumSizeWeightLimitInKG = 3;
        public const int LargeSizeWeightLimitInKG = 6;
        public const int XLSizeWeightLimitInKG = 10;
        public const int HeavySizeWeightLimitInKG = 50;

        public const decimal GenericOrderParcelListPrice = SmallSizePrice + MediumSizePrice + LargeSizePrice + XLSizePrice;

        public const int GenericOrderParcelListCount = 4;
        public const int GenericOrderParcelListCountSpeedy = 5;
        public const decimal OrderPriceMultipliersSpeedy = 2;
        public const decimal SmallSizePriceSpeedy = SmallSizePrice * OrderPriceMultipliersSpeedy;
        public const decimal GenericOrderParcelListPriceSpeedy = GenericOrderParcelListPrice * OrderPriceMultipliersSpeedy;


        public static Parcel SmallParcel() => new Parcel(1, 1, 1, ParcelSizeType.Small);
        public static Parcel MidParcel() => new Parcel(10, 10, 10, ParcelSizeType.Medium);
        public static Parcel LargeParcel() => new Parcel(50, 50, 50, ParcelSizeType.Large);
        public static Parcel XLParcel() => new Parcel(100, 100, 100, ParcelSizeType.XL);

        public static LineItem SmallLineItem() => new LineItem(SmallSizePrice, "Small");
        public static LineItem MidLineItem() => new LineItem(MediumSizePrice, "Medium");
        public static LineItem LargeLineIteml() => new LineItem(LargeSizePrice, "Large");
        public static LineItem XLineItem() => new LineItem(XLSizePrice, "XL");

        public static LineItem SpeedyItem(decimal amount) => new LineItem(amount, "Speedy");

        public static List<Parcel> GenericOrderParcelList() => new List<Parcel> { SmallParcel(), MidParcel(), LargeParcel(), XLParcel() };

        public static List<LineItem> GenericOrderParcelListItems() => new List<LineItem> { SmallLineItem(), MidLineItem(), LargeLineIteml(), XLineItem() };

        public static List<LineItem> GenericOrderParcelListItemsSpeedy() => new List<LineItem> { SmallLineItem(), MidLineItem(), LargeLineIteml(), XLineItem(), SpeedyItem(GenericOrderParcelListPrice) };
    }
}
