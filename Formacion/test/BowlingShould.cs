using FluentAssertions;
using Kata1;
using NUnit.Framework;

namespace test{
    public class BowlingShould{
        [Test]
        public void when_we_knocked_down_5_pins_on_the_first_roll_the_score_is_5(){
            var numberPinsKnocked = 5;
            var clsBowling = new ClsBowling();

            ClsBowling.Roll(numberPinsKnocked);

            ClsBowling.Score().Should().Be(numberPinsKnocked);
        }

        [Test]
        public void when_in_first_throw_we_knocked_down_10_pins_and_in_the_second_throw_5_the_score_is_20(){
            var fisrtNumberPinsKnocked = 10;
            var secondNumberPinsKnocked = 5;
            var clsBowling = new ClsBowling();
            ClsBowling.Roll(fisrtNumberPinsKnocked);

            ClsBowling.Roll(secondNumberPinsKnocked);

            var expectedNumberPinsKnocked = 20;
            ClsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        }

        [Test]
        public void when_in_first_throw_we_knocked_down_10_pins_the_next_two_throw_sum_double() {
            var fisrtNumberPinsKnocked = 10;
            var secondNumberPinsKnocked = 5;
            var thirdNumberPinsKnocked = 5;
            var clsBowling = new ClsBowling();
            ClsBowling.Roll(fisrtNumberPinsKnocked);
            ClsBowling.Roll(secondNumberPinsKnocked);

            ClsBowling.Roll(thirdNumberPinsKnocked);

            var expectedNumberPinsKnocked = 30;
            ClsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        }
    }
}
