using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRentalSystem.Domain.Tests
{
    public class DealerSpecs
    {
        [Fact]
        public void AddCarAdShouldSaveCarAd()
        {
            // Arrange
            var dealer = new Dealer("Valid dealer", "+12345678");
            var carAd = A.Dummy<CarAd>();

            // Act
            dealer.AddCarAd(carAd);

            // Assert
            dealer.CarAds.Should().Contain(carAd);
        }
    }
}
