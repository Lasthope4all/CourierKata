using System.Collections.Generic;

namespace CourierKata.Tests.Models
{
    public class OrderTests : BaseTest
    {
        [Fact]
        public void Check_Order_SmallParcel_Normal_ReturnsSmallPartialOrder()
        {
            // Act
            var sut = new Order(new List<Parcel> { SmallPartial() });

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().HaveCount(1);
                sut.Total.Should().Be(SmallSizePrice);
                sut.Type.Should().Be(OrderType.Normal);
            }
        }

        [Fact]
        public void Check_Order_SeveralParcels_Normal_ReturnsSeveralParcelsOrder()
        {
            // Act
            var sut = new Order(GenericOrderPartialList());

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().HaveCount(GenericOrderPartialListCount);
                sut.Total.Should().Be(GenericOrderPartialListPrice);
                sut.Type.Should().Be(OrderType.Normal);
            }
        }

        [Fact]
        public void Check_Order_SmallParcel_Speedy_ReturnsSmallPartialOrder()
        {
            // Act
            var sut = new Order(new List<Parcel> { SmallPartial() }, OrderType.Speedy);

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().HaveCount(2);
                sut.Total.Should().Be(SmallSizePriceSpeedy);
                sut.Type.Should().Be(OrderType.Speedy);
            }
        }

        [Fact]
        public void Check_Order_SeveralParcels_Speedy_ReturnsSeveralParcelsOrder()
        {
            // Act
            var sut = new Order(GenericOrderPartialList(), OrderType.Speedy);

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().HaveCount(GenericOrderPartialListCountSpeedy);
                sut.Total.Should().Be(GenericOrderPartialListPriceSpeedy);
                sut.Type.Should().Be(OrderType.Speedy);
            }
        }
    }
}
