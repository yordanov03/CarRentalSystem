using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;

namespace CarRentalSystem.Domain.Tests
{
    public class CarAdSpecs
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            //Arrange
            var carAd = A.Dummy<CarAd>();

            //Act
            carAd.ChangeAvailability();

            //Assert
            carAd.IsAvailable.Should().BeFalse();
        }

    }
}
