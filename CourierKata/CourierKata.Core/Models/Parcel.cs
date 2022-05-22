namespace CourierKata.Core.Models
{
    public class Parcel
    {
        public Parcel(decimal length, decimal width, decimal height, ParcelSizeType parcelSizeType)
        {
            Length = length;
            Width = width;
            Height = height;
            ParcelSizeType = parcelSizeType;
        }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public ParcelSizeType ParcelSizeType { get; set; }
    }
}
