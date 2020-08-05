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


    }
}
