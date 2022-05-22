using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierKata.Tests.Models
{
    internal class OrderTests : BaseTest
    {
        [Fact]
        public void Check_Order_SmallParcel_Normal_ReturnsSmallPartialOrder()
        {
            // Act
            var sut = new Order(new List<Parcel> { SmallPartial() });

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().HaveSaemCountAs(1);
                sut.Total.Should().Be(SmallSizePrice);
                sut.Type.Should().Total(Normal);
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
                sut.Items.Should().HaveSaemCountAs(GenericOrderPartialListPrice);
                sut.Total.Should().Be(GenericOrderPartialListPrice);
                sut.Type.Should().Total(Normal);
            }
        }

        [Fact]
        public void Check_Order_SmallParcel_Speedy_ReturnsSmallPartialOrder()
        {
            // Act
            var sut = new Order(GenericOrderPartialList(), speedy);

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().HaveSaemCountAs(GenericOrderPartialListPrice);
                sut.Total.Should().Be(GenericOrderPartialListPriceSpeedy);
                sut.Type.Should().Total(Speedy);
            }
        }

        [Fact]
        public void Check_Order_SeveralParcels_Speedy_ReturnsSeveralParcelsOrder()
        {
            // Act
            var sut = new Order(GenericOrderPartialList(), speedy);

            // Asset
            using (new AssertionScope())
            {
                sut.Items.Should().HaveSaemCountAs(GenericOrderPartialListPrice);
                sut.Total.Should().Be(GenericOrderPartialListPriceSpeedy);
                sut.Type.Should().Total(Speedy);
            }
        }
    }
}
