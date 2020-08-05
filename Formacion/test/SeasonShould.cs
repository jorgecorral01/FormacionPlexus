using System;
using NUnit.Framework;
using FluentAssertions;
using Kata1;

namespace test{
    public class SeasonShould{
        [Test]
        public void given_a_actual_date_return_his_season(){
            var date = DateTime.Now;
            var clsSeason = new ClsSeason();

            var actualSeason = clsSeason.GetSeason(date);

            actualSeason.Should().Be("Summer");
        }

        [Test]
        public void given_a_twenty_one_of_March_date_return_spring() {
            var date = Convert.ToDateTime("21/03/2020");
            var clsSeason = new ClsSeason();

            var actualSeason = clsSeason.GetSeason(date);

            actualSeason.Should().Be("Spring");
        }

        [Test]
        public void given_a_twenty_two_of_june_date_return_summer() {
            var date = Convert.ToDateTime("22/06/2019");
            var clsSeason = new ClsSeason();

            var actualSeason = clsSeason.GetSeason(date);

            actualSeason.Should().Be("Summer");
        }

        [Test]
        public void given_a_twenty_two_of_september_date_return_autumn() {
            var date = Convert.ToDateTime("22/09/2019");
            var clsSeason = new ClsSeason();

            var actualSeason = clsSeason.GetSeason(date);

            actualSeason.Should().Be("Autumn");
        }

        [Test]
        public void given_a_one_of_january_date_return_winter() {
            var date = Convert.ToDateTime("01/01/2019");
            var clsSeason = new ClsSeason();

            var actualSeason = clsSeason.GetSeason(date);

            actualSeason.Should().Be("Winter");
        }
    }
}
