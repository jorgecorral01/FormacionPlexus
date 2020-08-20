using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using Kata1.Exceptions;
using Kata1.Products;
using NUnit.Framework;

namespace test{
    public class GildedRoseSolidShould {
        [Test]
        public void quality_normal_degrade_when_sellin_value_not_has_passed() {
            var product = new AnyProduct { Sellin = 10, Quality = 10 };

            product.UpdateProduct();

            product.Sellin.Should().Be(9);
            product.Quality.Should().Be(9);
        }

        [Test]
        public void quality_double_degrade_when_sellin_value_has_passed() {
            var product = new AnyProduct { Sellin = -1, Quality = 10 };
            
            product.UpdateProduct();

            product.Sellin.Should().Be(-2);
            product.Quality.Should().Be(8);
        }

        [Test]
        public void when_quality_will_be_negative_return_gildedrose_exception_with_async_method() {
            var product = new AnyProduct() { Sellin = -1, Quality = 0 };
            
            var ex = Assert.Throws<GildedRoseException>(() => product.UpdateProduct());

            ex.MessageError.Should().Be("The quality never can be negative");
        }

        [Test]
        public void quality_increase_when_product_name_is_aged_brie() {
            var product = new AgedBrieProduct { Name = "Aged Brie", Sellin = 10, Quality = 10 };
            
            product.UpdateProduct();

            product.Sellin.Should().Be(9);
            product.Quality.Should().Be(11);
        }

        [Test]
        public void when_quality_will_be_greater_than_50_return_gildedrose_exception() {
            var product = new AgedBrieProduct { Name = "Aged Brie", Sellin = -1, Quality = 50 };
            
            var ex = Assert.Throws<GildedRoseException>(() => product.UpdateProduct());

            ex.MessageError.Should().Be("The quality never can be greater than 50");
        }

        [Test]
        public void quality_and_sellin_never_decrease_when_product_name_is_sulfuras() {
            var product = new SulfurasProduct { Name = "Sulfuras", Sellin = 10, Quality = 80 };
            
            product.UpdateProduct();

            product.Sellin.Should().Be(10);
            product.Quality.Should().Be(80);
        }

        [Test]
        public void quality_increase_in_one_when_sellin_greater_then_10_days_when_product_name_is_backstage_passes() {
            var product = new BackstagePassesProduct { Name = "Backstage passes", Sellin = 12, Quality = 10 };
            
            product.UpdateProduct();

            product.Sellin.Should().Be(11);
            product.Quality.Should().Be(11);
        }

        [Test]
        public void quality_increase_in_two_when_sellin_less_ten_days_or_less_when_product_name_is_backstage_passes() {
            var product = new BackstagePassesProduct { Name = "Backstage passes", Sellin = 11, Quality = 10 };

            product.UpdateProduct();

            product.Sellin.Should().Be(10);
            product.Quality.Should().Be(12);
        }

        [Test]
        public void quality_increase_in_three_when_sellin_less_5_days_or_less_when_product_name_is_backstage_passes() {
            var product = new BackstagePassesProduct { Name = "Backstage passes", Sellin = 6, Quality = 10 };
            
            product.UpdateProduct();

            product.Sellin.Should().Be(5);
            product.Quality.Should().Be(13);
        }

        [Test]
        public void quality_will_be_zero_when_sellin_will_be_zero_days_when_product_name_is_backstage_passes() {
            var product = new BackstagePassesProduct { Name = "Backstage passes", Sellin = 1, Quality = 10 };
            
            product.UpdateProduct();

            product.Sellin.Should().Be(0);
            product.Quality.Should().Be(0);
        }

        [Test]
        public void quality_decrease_in_two_when_product_name_is_conjured() {
            var product = new ConjuredProduct { Name = "Conjured", Sellin = 12, Quality = 10 };
            
            product.UpdateProduct();

            product.Sellin.Should().Be(11);
            product.Quality.Should().Be(8);
        }

        [Test]
        public void when_quality_for_sulfuras_is_diferent_to_80_return_gildedrose_exception() {
            var product = new SulfurasProduct { Name = "Sulfuras", Sellin = -1, Quality = 50 };

            var ex = Assert.Throws<GildedRoseException>(() => product.UpdateProduct());

            ex.MessageError.Should().Be("The quality Sulfuras always 80");
        }

        //[Test]
        //public async Task quality_for_sulfuras_never_change_of_80() {
        //    var product = new Product { Name = "Sulfuras", Sellin = 12, Quality = 80 };
        //    var gildedRose = new GildedRose();

        //    var actualProduct = await gildedRose.UpdateProduct(product);

        //    actualProduct.Sellin.Should().Be(12);
        //    actualProduct.Quality.Should().Be(80);
        //}
    }
}
