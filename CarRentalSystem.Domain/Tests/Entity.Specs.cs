using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Models.CarAds;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRentalSystem.Domain.Tests
{
    public class Entity
    {
        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual()
        {
            //Arrange
            var first = new Manufacturer("First").SetId(1);
            var second = new Manufacturer("Second").SetId(2);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
    internal static class EntityExtensions
    {
        public static Entity<T> SetId<T>(this Entity<T> entity, int id) where T : struct
        {
            entity
                    .GetType()
                    .BaseType!
                    .GetProperty(nameof(Entity<T>.Id))!
                    .GetSetMethod(true)!
                    .Invoke(entity, new object[] { id });

            return entity;
        }
    }
}
