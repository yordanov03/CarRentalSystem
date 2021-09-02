using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using System;
using Xunit;

namespace CarRentalSystem.Domain.Factories.CarAds
{
    public class CarAdFactorySpecs
    {
        [Fact]
        public void BuildWithAllPropertiesShouldNotThrowException()
        {
            //Arrange
            var carAdFactory = new CarAdFactory();

            //Act
            Action act = () => carAdFactory
            .WithManufacturer("New Manufacturer")
            .WithModel("Some model")
            .WithCategory("SUV", "Some description that must have twenty chars")
            .WithImageUrl("https://someurl.com")
            .WithOptions(true, 4, TransmissionType.Automatic)
            .WithPricePerDay(23)
            .Build();

            //Assert
            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void BuildWithNoManufacturerShouldThrowException()
        {
            //Arrange
            var carAdFactory = new CarAdFactory();

            //Act
            Action act = () => carAdFactory
            .WithModel("Some model")
            .WithCategory("Some category", "Some description that must have twenty chars")
            .WithImageUrl("https://someurl.com")
            .WithOptions(true, 4, TransmissionType.Automatic)
            .WithPricePerDay(23)
            .Build();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildWithNoCategoryShouldThrowException()
        {
            //Arrange
            var carAdFactory = new CarAdFactory();

            //Act
            Action act = () => carAdFactory
            .WithModel("Some model")
            .WithManufacturer("New Manufacturer")
            .WithImageUrl("https://someurl.com")
            .WithOptions(true, 4, TransmissionType.Automatic)
            .WithPricePerDay(23)
            .Build();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildWithNoModelShouldThrowException()
        {
            //Arrange
            var carAdFactory = new CarAdFactory();

            //Act
            Action act = () => carAdFactory
            .WithCategory("Some category", "Some description that must have twenty chars")
            .WithManufacturer("New Manufacturer")
            .WithImageUrl("https://someurl.com")
            .WithOptions(true, 4, TransmissionType.Automatic)
            .WithPricePerDay(23)
            .Build();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildWithNoImageUrlShouldThrowException()
        {
            //Arrange
            var carAdFactory = new CarAdFactory();

            //Act
            Action act = () => carAdFactory
            .WithCategory("Some category", "Some description that must have twenty chars")
            .WithManufacturer("New Manufacturer")
            .WithModel("Some model")
            .WithOptions(true, 4, TransmissionType.Automatic)
            .WithPricePerDay(23)
            .Build();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildWithNoOptionsShouldThrowException()
        {
            //Arrange
            var carAdFactory = new CarAdFactory();

            //Act
            Action act = () => carAdFactory
            .WithCategory("Some category", "Some description that must have twenty chars")
            .WithManufacturer("New Manufacturer")
            .WithModel("Some model")
            .WithImageUrl("https://someurl.com")
            .WithPricePerDay(23)
            .Build();

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldCreateCarAdIfEveryPropertyIsSet()
        {
            // Assert
            var carAdFactory = new CarAdFactory();

            // Act
            var carAd = carAdFactory
                .WithManufacturer("TestManufacturer")
                .WithCategory("SUV", "TestCategoryDescription")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .WithImageUrl("http://test.image.url")
                .WithModel("TestModel")
                .WithPricePerDay(10)
                .Build();

            // Assert
            carAd.Should().NotBeNull();
        }
    }
}
