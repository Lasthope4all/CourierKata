using System.Collections.Generic;

namespace CourierKata.Tests.Models
{
    public class OrderTests : BaseTest
    {
        [Fact]
        public void Check_Order_SmallParcel_Normal_ReturnsSmallParcelOrder()
        {
            // Act
            var sut = new Order(new List<Parcel> { SmallParcel() });

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().BeEquivalentTo(new List<LineItem> { SmallLineItem() });
                sut.Total.Should().Be(SmallSizePrice);
                sut.Type.Should().Be(OrderType.Normal);
            }
        }

        [Fact]
        public void Check_Order_SeveralParcels_Normal_ReturnsSeveralParcelsOrder()
        {
            // Act
            var sut = new Order(GenericOrderParcelList());

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().BeEquivalentTo(GenericOrderParcelListItems());
                sut.Total.Should().Be(GenericOrderParcelListPrice);
                sut.Type.Should().Be(OrderType.Normal);
            }
        }

        [Fact]
        public void Check_Order_SmallParcel_Speedy_ReturnsSmallParcelOrder()
        {
            // Act
            var sut = new Order(new List<Parcel> { SmallParcel() }, OrderType.Speedy);

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().BeEquivalentTo(new List<LineItem> { SmallLineItem(), SpeedyItem(SmallSizePrice) });
                sut.Total.Should().Be(SmallSizePriceSpeedy);
                sut.Type.Should().Be(OrderType.Speedy);
            }
        }

        [Fact]
        public void Check_Order_SeveralParcels_Speedy_ReturnsSeveralParcelsOrder()
        {
            // Act
            var sut = new Order(GenericOrderParcelList(), OrderType.Speedy);

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().BeEquivalentTo(GenericOrderParcelListItemsSpeedy());
                sut.Total.Should().Be(GenericOrderParcelListPriceSpeedy);
                sut.Type.Should().Be(OrderType.Speedy);
            }
        }
    }
}
