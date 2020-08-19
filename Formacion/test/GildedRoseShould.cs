using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using Kata1.Exceptions;
using NUnit.Framework;

namespace test{
    public class GildedRoseShould{
        [Test]
        public async Task quality_normal_degrade_when_sellin_value_not_has_passed(){
            var product = new Product{Sellin = 10, Quality = 10};
            var gildedRose = new GildedRose();

            var actualProduct = await gildedRose.UpdateProduct(product);

            actualProduct.Quality.Should().Be(9);
            actualProduct.Sellin.Should().Be(9);
        }

        [Test]
        public async Task  quality_double_degrade_when_sellin_value_has_passed() {
            var product = new Product { Sellin = -1, Quality = 10 };
            var gildedRose = new GildedRose();

            var actualProduct = await gildedRose.UpdateProduct(product);

            actualProduct.Quality.Should().Be(8);
            actualProduct.Sellin.Should().Be(-2);
        }

        [Test]
        public void when_quality_will_be_negative_return_gildedrose_exception(){
            var product = new Product { Sellin = -1, Quality = 0 };
            var gildedRose = new GildedRose();

            Func<Task> action = async () => await gildedRose.UpdateProduct(product); ;

            action.Should().ThrowExactly<GildedRoseException>().Which.MessageError.Should().Be("The quality never can be negative");
        }

        [Test]
        public async Task quality_increase_when_product_name_is_aged_brie() {
            var product = new Product {Name = "Aged Brie", Sellin = 10, Quality = 10 };
            var gildedRose = new GildedRose();

            var actualProduct = await gildedRose.UpdateProduct(product);

            actualProduct.Quality.Should().Be(11);
            actualProduct.Sellin.Should().Be(9);
        }

        [Test]
        public void when_quality_will_be_greater_than_50_return_gildedrose_exception() {
            var product = new Product { Name = "Aged Brie", Sellin = -1, Quality = 50 };
            var gildedRose = new GildedRose();

            Func<Task> action = async () => await gildedRose.UpdateProduct(product); ;

            action.Should().ThrowExactly<GildedRoseException>().Which.MessageError.Should().Be("The quality never can be greater than 50");
        }
    }
}
