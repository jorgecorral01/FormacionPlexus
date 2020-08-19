﻿using System;
using System.Net.Http.Headers;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using NUnit.Framework;

namespace test{
    public class GildedRoseShould{
        [Test]
        public void quality_normal_degrade_when_sellin_value_not_has_passed(){
            var product = new Product{Sellin = 10, Quality = 10};
            var gildedRose = new GildedRose();

            var actualProduct =  gildedRose.UpdateProduct(product);

            actualProduct.Quality.Should().Be(9);
        }

        [Test]
        public void quality_double_degrade_when_sellin_value_has_passed() {
            var product = new Product { Sellin = -1, Quality = 10 };
            var gildedRose = new GildedRose();

            var actualProduct = gildedRose.UpdateProduct(product);

            actualProduct.Quality.Should().Be(8);
        }
    }
}
