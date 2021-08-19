using System;
using Xunit;
using FluentAssertions;
using CarRentalSystem.Domain.Models.CarAds;

namespace CarRentalSystem.Test
{
    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            //Act
            Action act = () => new Category("Valid Name", "Valid description");

            //Assert
            act.Should().NotThrow<>
        }
    }
}
