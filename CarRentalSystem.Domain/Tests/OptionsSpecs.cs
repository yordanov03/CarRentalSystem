using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models;
using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Tests
{
    public class OptionsSpecs
    {
        [Fact]
        public void CreateOptionsSuccessfully()
        {
            //Arrange
            Action options = () => new Options(true, 4, TransmissionType.Automatic);

            //Assert
            options.Should().NotThrow<InvalidOptionsException>();
        }

        [Fact]
        public void LessThanMinSeatShouldThrowException()
        {
            //Arrange
            Action options = () => new Options(true, ModelConstants.Options.MinNumberOfSeats - 1, TransmissionType.Automatic);

            //Assert
            options.Should().Throw<InvalidOptionsException>();
        }

        [Fact]
        public void MoreThanMinSeatShouldThrowException()
        {
            //Arrange
            Action options = () => new Options(true, ModelConstants.Options.MaxNumberOfSeats + 1, TransmissionType.Automatic);

            //Assert
            options.Should().Throw<InvalidOptionsException>();
        }
    }
}
