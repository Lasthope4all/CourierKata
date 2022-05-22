using System;

namespace CourierKata.Tests.Factory
{
    public class ParcelFactoryTests
    {
        private ParcelFactory _parcelFactory;
        public ParcelFactoryTests()
        {
            _parcelFactory = new ParcelFactory();
        }


        // Small parcel: all dimensions< 10cm. Cost $3
        [Theory]
        [InlineData(0.1, 0.1, 0.1)]
        [InlineData(1, 1, 1)]
        [InlineData(5, 5, 5)]
        [InlineData(9.9, 9.9, 9.9)]
        public void Check_ParcelFactory_Createparcel_ReturnsSmallType(decimal length, decimal width, decimal height)
        {
            // Act
            var sut = _parcelFactory.CreateParcel(height, length, width);

            // Asset
            AssertParcelIsValid(sut, height, length, width, ParcelSizeType.Small);
        }

        // Medium parcel: all dimensions < 50cm.Cost $8
        [Theory]
        [InlineData(1, 1, 10)]
        [InlineData(10, 10, 10)]
        [InlineData(49.9, 49.9, 49.9)]
        [InlineData(40, 40, 49.9)]
        public void Check_ParcelFactory_Createparcel_ReturnsMediumType(decimal length, decimal width, decimal height)
        {
            // Act
            var sut = _parcelFactory.CreateParcel(height, length, width);

            // Asset
            AssertParcelIsValid(sut, height, length, width, ParcelSizeType.Medium);
        }

        // Large parcel: all dimensions < 100cm.Cost $15 
        [Theory]
        [InlineData(1, 1, 99)]
        [InlineData(5.7, 99, 90)]
        [InlineData(2, 90, 99.9)]
        [InlineData(99.9, 99.9, 99.9)]
        public void Check_ParcelFactoryCreateparcel_ReturnsLargeType(decimal length, decimal width, decimal height)
        {
            // Act
            var sut = _parcelFactory.CreateParcel(height, length, width);

            // Asset
            AssertParcelIsValid(sut, height, length, width, ParcelSizeType.Large);
        }

        // XL parcel: any dimension >= 100cm. Cost $25
        [Theory]
        [InlineData(1, 1, 100)]
        [InlineData(1243, 1000, 100)]
        [InlineData(100, 100, 100)]
        [InlineData(100.00, 100.00, 100.00)]
        public void Check_ParcelFactory_Createparcel_ReturnsXLType(decimal length, decimal width, decimal height)
        {
            // Act
            var sut = _parcelFactory.CreateParcel(height, length, width);

            // Asset
            AssertParcelIsValid(sut, height, length, width, ParcelSizeType.XL);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(-1, -1, 0)]
        [InlineData(0, -1, -1)]
        [InlineData(-1, 0, -1)]
        [InlineData(-1, -1, -1)]
        public void Check_ParcelFactory_Createparcel_ThrowsException_OnZeroOrBelowValue(decimal length, decimal width, decimal height)
        {
            // Asset
            _parcelFactory.Invoking(x => x.CreateParcel(height, length, width)).Should().Throw<ArgumentOutOfRangeException>();
        }

        // To reduce duplication all the test assertions can be done together in thid classs.
        private void AssertParcelIsValid(Parcel parcel, decimal length, decimal width, decimal height, ParcelSizeType parcelSizeType)
        {
            using (new AssertionScope())
            {
                parcel.ParcelSizeType.Should().Be(parcelSizeType);
                parcel.Length.Should().Be(length);
                parcel.Width.Should().Be(width);
                parcel.Height.Should().Be(height);
            }
        }
    }
}
