using System;
using NUnit.Framework;
using FluentAssertions;
using Kata1;
using Kata1.interfaces;
using NSubstitute;

namespace test{
    public class SeasonShould{
        
        [Test]
        public void given_a_twenty_one_of_March_date_return_spring() {
            var clock = Substitute.For<iClock>();
            clock.Now().Returns(Convert.ToDateTime("21/03/2020"));
            var clsSeason = new ClsSeason(clock);

            var actualSeason = clsSeason.GetSeason();

            actualSeason.Should().Be("Spring");
        }

        [Test]
        public void given_a_twenty_two_of_june_date_return_summer() {
            var clock = Substitute.For<iClock>();
            clock.Now().Returns(Convert.ToDateTime("22/06/2019"));
            var clsSeason = new ClsSeason(clock);

            var actualSeason = clsSeason.GetSeason();

            actualSeason.Should().Be("Summer");
        }

        [Test]
        public void given_a_twenty_two_of_september_date_return_autumn() {
            var clock = Substitute.For<iClock>();
            clock.Now().Returns(Convert.ToDateTime("22/09/2019"));
            var clsSeason = new ClsSeason(clock);

            var actualSeason = clsSeason.GetSeason();

            actualSeason.Should().Be("Autumn");
        }

        [Test]
        public void given_a_one_of_january_date_return_winter() {
            var clock = Substitute.For<iClock>();
            clock.Now().Returns(Convert.ToDateTime("01/01/2019"));
            var clsSeason = new ClsSeason(clock);

            var actualSeason = clsSeason.GetSeason();

            actualSeason.Should().Be("Winter");
        }

        [Test]
        public void given_a_one_of_january_date_return_winter_with_mock_clock() {
            var clock = Substitute.For<iClock>();
            clock.Now().Returns(Convert.ToDateTime("01/01/2019"));
            var clsSeason = new ClsSeason(clock);

            var actualSeason = clsSeason.GetSeason();

            actualSeason.Should().Be("Winter");
        }
    }
}
