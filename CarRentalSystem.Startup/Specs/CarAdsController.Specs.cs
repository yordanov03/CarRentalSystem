using CarRentalSystem.Application;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Web.Features;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Linq;
using Xunit;
using FakeItEasy;
using System.Collections.Generic;

namespace CarRentalSystem.Startup.Specs
{
    public class CarAdsController
    {
        [Fact]
        public void GetShouldReturnAllCarAdsWithoutAQuery()
        {
            var carAd = new Mock<IRepository<CarAd>>();
            //carAd.Setup(c => c.All()).Returns(GetMoqObject());
            var optionsRepo = new Mock<IOptions<ApplicationSettings>>();
            var controller = new CarsAdController(carAd.Object, optionsRepo.Object);

            var response = controller.Get();

            carAd.Verify(c => c.All());
        }

        [Fact]
        public void GetShouldNotReturnNull()
        {
            var carAd = new Mock<IRepository<CarAd>>();
            var optionsRepo = new Mock<IOptions<ApplicationSettings>>();
            var controller = new CarsAdController(carAd.Object, optionsRepo.Object);

            var response = controller.Get();

            Assert.NotNull(response);
        }

        //private IQueryable<CarAd> GetMoqObject()
        //{
        //    var car1 = A.Dummy<CarAd>();
        //    var car2 = A.Dummy<CarAd>();
        //    var collection = new List<CarAd>();
        //    collection.Add(car1);
        //    collection.Add(car2);

        //    return collection.AsQueryable();
        //}
    }
}
