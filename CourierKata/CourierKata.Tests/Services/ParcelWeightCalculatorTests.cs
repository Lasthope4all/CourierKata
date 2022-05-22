using CourierKata.Core.Services;
using System;
using System.Collections.Generic;

namespace CourierKata.Tests.Services
{
    public class ParcelWeightCalculatorTests : BaseTest
    {
        private ParcelWeightCalculator _parcelWeightCalculatorTests;

        public ParcelPriceCalculatorTests()
        {
            _parcelWeightCalculatorTests = new ParcelPriceCalculator();
        }

        [Theory]
        [MemberData(nameof(ParcelSizeTypeValues))]
        public void Check_ParcelWeightCalculator_WeightIsZero_ReturnsZero(ParcelSizeType parcelType)
        {
            // Arrange
            var weight = 0;

            // Act
            var sut = _parcelWeightCalculatorTests.CalculateOverWeightOfParcel(parcelType, weight);

            // Asset
            sut.Should().Be(weight);
        }

        [Theory]
        [MemberData(nameof(ParcelSizeTypeValues))]
        public void Check_ParcelWeightCalculator_WeightIsPositive_ReturnsSame(ParcelSizeType parcelType)
        {
            // Arrange
            var weight = 100;

            // Act
            var sut = _parcelWeightCalculatorTests.CalculateOverWeightOfParcel(parcelType, weight);

            // Asset
            sut.Should().BeLessThan(weight).And.BeGreaterThan(0);
        }

        [Theory]
        [MemberData(nameof(ParcelSizeTypeValues))]
        public void Check_ParcelWeightCalculator_WeightIsBelowZero_ReturnsZero(ParcelSizeType parcelType)
        {
            var weight = -1000;

            // Act
            var sut = _parcelWeightCalculatorTests.CalculateOverWeightOfParcel(parcelType, weight);

            // Asset
            sut.Should().Be(0);
        }

        [Fact]
        public void Check_ParcelWeightCalculator_InvalidParcelType_ThrowsException()
        {
            // Asset
            _parcelWeightCalculatorTests.Invoking(x => x.CalculateOverWeightOfParcel((ParcelSizeType)100, 10)).Should().Throw<ArgumentOutOfRangeException>();
        }


        [Theory] // issue in passing in const. Would make line data if it worked right off the bat.
        [InlineData(0, 0)]
        [InlineData(3, 3)]
        [InlineData(-3, 0)]
        public void Check_ParcelHelper_GetOverWeightInKG_Small_ReturnsExspectedWeight(decimal additonalWeight, decimal exspectedWeight)
        {
            // Arrange
            var weight = SmallSizeWeightLimitInKG + additonalWeight;

            // Act
            var sut = _parcelWeightCalculatorTests.CalculateOverWeightOfParcel(ParcelSizeType.Small, weight);

            // Asset
            sut.Should().Be(exspectedWeight);
        }

        [Theory] // issue in passing in const. Would make line data if it worked right off the bat.
        [InlineData(0, 0)]
        [InlineData(3, 3)]
        [InlineData(-3, 0)]
        public void Check_ParcelHelper_GetOverWeightInKG_Medium_ReturnsExspectedWeight(decimal additonalWeight, decimal exspectedWeight)
        {
            // Arrange
            var weight = MediumSizeWeightLimitInKG + additonalWeight;

            // Act
            var sut = _parcelWeightCalculatorTests.CalculateOverWeightOfParcel(ParcelSizeType.Medium, weight);

            // Asset
            sut.Should().Be(exspectedWeight);
        }

        [Theory] // issue in passing in const. Would make line data if it worked right off the bat.
        [InlineData(0, 0)]
        [InlineData(3, 3)]
        [InlineData(-3, 0)]
        public void Check_ParcelHelper_GetOverWeightInKG_Large_ReturnsExspectedWeight(decimal additonalWeight, decimal exspectedWeight)
        {
            // Arrange
            var weight = LargeSizeWeightLimitInKG + additonalWeight;

            // Act
            var sut = _parcelWeightCalculatorTests.CalculateOverWeightOfParcel(ParcelSizeType.Large, weight);

            // Asset
            sut.Should().Be(exspectedWeight);
        }

        [Theory] // issue in passing in const. Would make line data if it worked right off the bat.
        [InlineData(0, 0)]
        [InlineData(3, 3)]
        [InlineData(-3, 0)]
        public void Check_ParcelHelper_GetOverWeightInKG_XL_ReturnsExspectedWeight(decimal additonalWeight, decimal exspectedWeight)
        {
            // Arrange
            var weight = XLSizeWeightLimitInKG + additonalWeight;

            // Act
            var sut = _parcelWeightCalculatorTests.CalculateOverWeightOfParcel(ParcelSizeType.XL, weight);

            // Asset
            sut.Should().Be(exspectedWeight);
        }

        public static IEnumerable<object[]> ParcelSizeTypeValues()
        {
            foreach (var enumValue in Enum.GetValues(typeof(ParcelSizeType)))
            {
                yield return new object[] { enumValue };
            }
        }
    }
}
