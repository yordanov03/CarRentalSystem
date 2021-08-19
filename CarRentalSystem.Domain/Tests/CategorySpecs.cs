using System;
using Xunit;
using FluentAssertions;
using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models;

namespace CarRentalSystem.Test
{
    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            //Act
            Action act = () => new Category("Valid Name", "Valid description Valid description");

            //Assert
            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void EmptyCategoryNameShouldThrowException()
        {
            //Act
            Action act = () => new Category("", "Valid decription");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void EmptyDescriptionShouldThrowException()
        {
            //Act
            Action act = () => new Category("Valid name", "");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void DescriptionCharsAboveMaxShouldThrowException()
        {
            //Act
            Action act = () => new Category("Valid name", new string('a',ModelConstants.Category.MaxDescriptionLength+1));

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void NameCharsAboveMaxShouldThrowException()
        {
            //Act
            Action act = () => new Category(new string('a', ModelConstants.Common.MaxNameLength + 1), "Valid description Valid description");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }
    }
}
