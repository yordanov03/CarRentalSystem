using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Models.CarAds;
using System;
using System.Collections.Generic;

namespace CarRentalSystem.Domain.Models.InitialData
{
    internal class CarAdData : IInitialData
    {
        public Type EntityType => typeof(CarAd);

        public IEnumerable<object> GetData()
            => new List<CarAd>
            {
               //new CarAd("Opel", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Opel_Astra_1.6_CDTI_ecoFLEX_Dynamic_%28K%29_%E2%80%93_Frontansicht%2C_23._Dezember_2016%2C_D%C3%BCsseldorf_%28cropped%29.jpg/1200px-Opel_Astra_1.6_CDTI_ecoFLEX_Dynamic_%28K%29_%E2%80%93_Frontansicht%2C_23._Dezember_2016%2C_D%C3%BCsseldorf_%28cropped%29.jpg",24,true),
               //new CarAd("Mazda", "https://www.mazda.bg/Portals/6/adam/ModelData/-sdZTHfQ9EK5lzM4b_lXbw/Image/mazda3.png",32,true),
               //new CarAd("Mercedes", "https://www.mercedes-benz.bg/passengercars/_jcr_content/image.MQ6.2.2x.20210826160445.png",124,true),
               //new CarAd("BMW", "https://bmw-autobavaria.bg/files/cars/serie-1-m135i.png?3e9fa92b1d",64,true),
               //new CarAd("Opel", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Opel_Astra_1.6_CDTI_ecoFLEX_Dynamic_%28K%29_%E2%80%93_Frontansicht%2C_23._Dezember_2016%2C_D%C3%BCsseldorf_%28cropped%29.jpg/1200px-Opel_Astra_1.6_CDTI_ecoFLEX_Dynamic_%28K%29_%E2%80%93_Frontansicht%2C_23._Dezember_2016%2C_D%C3%BCsseldorf_%28cropped%29.jpg",24,false),

               new CarAd(
                   new Manufacturer("Valid Manufacturer"),
                   "Valid Model",
                   new Category("SUV", "Valid decription text"),
                   "https://valid.test",
                   10,
                   new Options(true,4, TransmissionType.Automatic),
                   true)
            };
    }
}
