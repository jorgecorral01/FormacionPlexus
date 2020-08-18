using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kata1;
using Kata1.Exceptions;
using NUnit.Framework;

namespace test{
    public class BowlingShould{
        private ClsBowling clsBowling;

        [SetUp]
        public void Setup(){
            clsBowling = new ClsBowling();
        }

        [Test]
        public async Task when_we_knocked_down_5_pins_on_the_first_roll_the_score_is_5(){
            var numberPinsKnocked = 5;

            await clsBowling.Roll(numberPinsKnocked);

            clsBowling.Score().Should().Be(numberPinsKnocked);
        }

        [Test]
        public async Task when_in_first_throw_we_knocked_down_10_pins_and_in_the_second_throw_5_the_score_is_20(){
            var fisrtNumberPinsKnocked = 10;
            var secondNumberPinsKnocked = 5;
            await clsBowling.Roll(fisrtNumberPinsKnocked);

            await clsBowling.Roll(secondNumberPinsKnocked);

            var expectedNumberPinsKnocked = 20;
            clsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        }

        [Test]
        public async Task when_do_strike_the_next_two_throw_sum_double() {
            var fisrtNumberPinsKnocked = 10;
            var secondNumberPinsKnocked = 5;
            var thirdNumberPinsKnocked = 5;
            await clsBowling.Roll(fisrtNumberPinsKnocked);
            await clsBowling.Roll(secondNumberPinsKnocked);

            await clsBowling.Roll(thirdNumberPinsKnocked);

            var expectedNumberPinsKnocked = 35;
            clsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        }

        [Test]
        public async Task when_do_spare_the_next_throw_sum_double() {
            var fisrtNumberPinsKnocked = 1;
            var secondNumberPinsKnocked = 9;
            var thirdNumberPinsKnocked = 5;
            await clsBowling.Roll(fisrtNumberPinsKnocked);
            await clsBowling.Roll(secondNumberPinsKnocked);

            await clsBowling.Roll(thirdNumberPinsKnocked);

            var expectedNumberPinsKnocked = 20;
            clsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        }

        [Test]
        public async Task when_try_do_11_throw_we_recieved_that_only_ten_times() {
            await LaunchTenThrowsWithOutSpareOrStrike();

            Func<Task> action = async () => await clsBowling.Roll(1);

            action.Should().ThrowExactly<TrowsException>().Which.MessageError.Should().Be("Only ten throws");
        }
        
        [Test]
        public async Task when_in_ten_throw_we_have_strike_or_spare_we_can_do_another_throw(){
            await LaunchTenThrows();

            await clsBowling.Roll(1);

            clsBowling.Score().Should().Be(20);
        }

        [Test]
        public async Task when_do_the_best_game_the_score_will_be_300() {
            await LaunchTenThrowsWithStrikes();

            await clsBowling.Roll(10);

            clsBowling.Score().Should().Be(300);
        }

        private async Task LaunchTenThrows(){
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(9);
        }

        private async Task LaunchTenThrowsWithOutSpareOrStrike() {
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
            await clsBowling.Roll(1);
        }
        private async Task LaunchTenThrowsWithStrikes() {
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
            await clsBowling.Roll(10);
        }
    }
}
