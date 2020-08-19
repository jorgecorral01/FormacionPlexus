using System;
using System.Net.Http.Headers;
using FluentAssertions;
using NUnit.Framework;

namespace test{
    public class GildedRoseShould{
        [Test]
        public void quality_normal_degrade_when_sellin_value_not_has_passed(){
            var actualdate = DateTime.Now;
            var product = new Product{Sellin = DateTime.Now.AddDays(33), Quality = 10};
            var gildedRose = new GildedRose();

            var actualProduct =  gildedRose.UpdateProduct(actualdate, product);

            actualProduct.Quality.Should().Be(9);
        }

        [Test]
        public void quality_double_degrade_when_sellin_value_has_passed() {
            var actualdate = DateTime.Now;
            var product = new Product { Sellin = DateTime.Now.AddDays(-3), Quality = 10 };
            var gildedRose = new GildedRose();

            var actualProduct = gildedRose.UpdateProduct(actualdate, product);

            actualProduct.Quality.Should().Be(8);
        }
    }

    public class GildedRose
    {
        public Product UpdateProduct(DateTime actualdate, Product product){
            if (product.Sellin > actualdate){
                product.Quality -= 1;
            }

            return product;
        }
    }

    public class Product{
        public DateTime Sellin{ get; set; }
        public int Quality{ get; set; }
    }
}
