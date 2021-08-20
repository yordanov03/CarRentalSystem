using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models;
using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Tests
{
    public class ManufacturerSpecs
    {
        [Fact]
        public void ManufacturerCreationShouldNotThrowException()
        {
            //Arrange
            Action manucaturer = () => new Manufacturer("New manufacturer");

            //Assert
            manucaturer.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void NoManufacturerNameShouldThrowException()
        {
            //Arrange
            Action manucaturer = () => new Manufacturer(string.Empty);

            //Assert
            manucaturer.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void LongManufacturerNameShouldThrowException()
        {
            //Arrange
            Action manucaturer = () => new Manufacturer(new string('*', ModelConstants.Common.MaxNameLength + 1));

            //Assert
            manucaturer.Should().Throw<InvalidCarAdException>();
        }
    }
}
