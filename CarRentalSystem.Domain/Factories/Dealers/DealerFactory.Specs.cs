using CarRentalSystem.Domain.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRentalSystem.Domain.Factories.Dealers
{
    public class DealerFactorySpecs
    {
        [Fact]
        public void SuccessfullyCreateDealerWithAllProperties()
        {
            //Arrange
            var dealer = new DealerFactory();

            //Act
           Action act = ()=> dealer
                .WithName("Some dealer name")
                .WithPhoneNumber("+112343444")
                .Build();

            //Assert
            act.Should().NotThrow<InvalidDealerException>();
        }

        [Fact]
        public void CreatingDealerWithNoNameShouldThrowException()
        {
            //Arrange
            var dealer = new DealerFactory();

            //Act
            Action act = () => dealer
                 .WithPhoneNumber("+112343444")
                 .Build();

            //Assert
            act.Should().Throw<InvalidDealerException>();
        }

        [Fact]
        public void CreatingDealerWithNoPhoneNumberShouldNotThrowException()
        {
            //Arrange
            var dealer = new DealerFactory();

            //Act
            Action act = () => dealer
                 .WithName("Some dealer name")
                 .Build();

            //Assert
            act.Should().NotThrow<InvalidDealerException>();
        }
    }
}
