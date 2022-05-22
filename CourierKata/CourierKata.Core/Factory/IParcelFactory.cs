namespace CourierKata.Core.Factory
{
    public interface IParcelFactory
    {
        public Parcel CreateParcel(decimal length, decimal width, decimal height);
    }
}
