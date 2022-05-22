using CourierKata.Core.Services;
using System;

namespace CourierKata.Tests.Services
{
    public class ParcelPriceCalculatorTests
    {
        public const decimal SmallSizePrice = 3;
        public const decimal MediumSizePrice = 8;
        public const decimal LargeSizePrice = 15;
        public const decimal XLSizePrice = 25;
        public const decimal HeavySizePrice = 50;

        private ParcelPriceCalculator _parcelPriceCalculator;

        public ParcelPriceCalculatorTests()
        {
            _parcelPriceCalculator = new ParcelPriceCalculator();
        }

        [Fact]
        public void Check_ParcelPriceCalculator_GetParcelPrice_ReturnsSmallTypePrice()
        {
            // Act
            var sut = _parcelPriceCalculator.GetParcelPrice(ParcelSizeType.Small);
            // Asset
            sut.Should().Be(SmallSizePrice);
        }


        [Fact]
        public void Check_ParcelPriceCalculator_GetParcelPrice_ReturnsMediumTypePrice()
        {
            // Act
            var sut = _parcelPriceCalculator.GetParcelPrice(ParcelSizeType.Medium);

            // Asset
            sut.Should().Be(MediumSizePrice);
        }


        [Fact]
        public void Check_ParcelPriceCalculator_GetParcelPrice_ReturnsLargeTypePrice()
        {
            // Act
            var sut = _parcelPriceCalculator.GetParcelPrice(ParcelSizeType.Large);

            // Asset
            sut.Should().Be(LargeSizePrice);
        }

        [Fact]
        public void Check_ParcelPriceCalculator_GetParcelPrice_ReturnsXLPrice()
        {
            // Act
            var sut = _parcelPriceCalculator.GetParcelPrice(ParcelSizeType.XL);

            // Asset
            sut.Should().Be(XLSizePrice);
        }

        [Fact]
        public void Check_parcelPriceCalculator_GetParcelPrice_ThrowsException_NotCorrectType()
        {
            // Asset
            _parcelPriceCalculator.Invoking(x => x.GetParcelPrice((ParcelSizeType)123654)).Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
