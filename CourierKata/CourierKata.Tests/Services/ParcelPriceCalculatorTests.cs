using System;
using System.Collections.Generic;

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
            _ParcelPriceCalculator = new ParcelPriceCalculator();
        }

        [Fact]
        public void Check_ParcelPriceCalculator_GetPrice_ReturnsSmallTypePrice()
        {
            // Act
            var sut = _ParcelPriceCalculator.GetPrice(ParcelSizeType.Small);
            // Asset
            sut.Should.Be(SmallSizePrice);
        }


        [Fact]
        public void Check_ParcelPriceCalculator_GetPrice_ReturnsMediumTypePrice()
        {
            // Act
            var sut = _ParcelPriceCalculator.GetPrice(ParcelSizeType.Medium);

            // Asset
            sut.Should.Be(MediumSizePrice);
        }


        [Fact]
        public void Check_ParcelPriceCalculator_GetPrice_ReturnsLargeTypePrice()
        {
            // Act
            var sut = _ParcelPriceCalculator.GetPrice(ParcelSizeType.Large);

            // Asset
            sut.Should.Be(LargeSizePrice);
        }

        [Fact]
        public void Check_ParcelPriceCalculator_GetPrice_ReturnsXLPrice()
        {
            // Act
            var sut = _ParcelPriceCalculator.GetPrice(ParcelSizeType.XL);

            // Asset
            sut.Should.Be(XLSizePrice);
        }

        [Fact]
        public void Check_parcelPriceCalculator_GetPrice_ThrowsException_NotCorrectType()
        {
            // Asset
            _ParcelPriceCalculator.Invoking(x => x.GetPrice((ParcelSizeType)123654)).Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
