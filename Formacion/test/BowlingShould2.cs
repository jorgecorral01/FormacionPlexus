using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kata1;
using Kata1.Exceptions;
using NUnit.Framework;

namespace test{
    public class BowlingShould2{
        private ClsBowling2 clsBowling2;

        [SetUp]
        public void Setup(){
            clsBowling2 = new ClsBowling2();
        }

        [Test]
        public void when_we_knocked_down_5_pins_on_the_first_roll_the_score_is_5(){
            var numberPinsKnocked = new int[10] { 5, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            clsBowling2.Roll(numberPinsKnocked);

            var expectedScore = 5;
            clsBowling2.Score().Should().Be(expectedScore);
        }

        //[Test]
        //public void when_in_first_throw_we_knocked_down_10_pins_and_in_the_second_throw_5_the_score_is_15(){
        //    var fisrtNumberPinsKnocked = 10;
        //    var secondNumberPinsKnocked = 5;
        //     ClsBowling.Roll(fisrtNumberPinsKnocked);

        //      ClsBowling.Roll(secondNumberPinsKnocked);

        //    var expectedNumberPinsKnocked = 15;
        //    ClsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        //}

        //[Test]
        //public void when_do_strike_the_next_two_throw_sum_double() {
        //    var fisrtNumberPinsKnocked = 10;
        //    var secondNumberPinsKnocked = 5;
        //    var thirdNumberPinsKnocked = 5;
        //    var fourthNumberPinsKnocked = 1;
        //     ClsBowling.Roll(fisrtNumberPinsKnocked);
        //     ClsBowling.Roll(secondNumberPinsKnocked);

        //     ClsBowling.Roll(thirdNumberPinsKnocked);
        //     ClsBowling.Roll(fourthNumberPinsKnocked);

        //    var expectedNumberPinsKnocked = 27;
        //    ClsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        //}

        //[Test]
        //public void when_do_spare_the_next_throw_sum_double() {
        //    var firstNumberPinsKnocked = 1;
        //    var secondNumberPinsKnocked = 9;
        //    var thirdNumberPinsKnocked = 5;
        //    var fourthNumberPinsKnocked = 5;
        //    ClsBowling.Roll(firstNumberPinsKnocked);
        //    ClsBowling.Roll(secondNumberPinsKnocked);

        //    ClsBowling.Roll(thirdNumberPinsKnocked);
        //    ClsBowling.Roll(fourthNumberPinsKnocked);

        //    var expectedNumberPinsKnocked = 25;
        //    ClsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        //}

        //[Test]
        //public void when_try_do_11_throw_we_recieved_that_only_ten_times() {
        //     LaunchTenThrowsWithOutSpareOrStrike();

        //    Func<Task> action = async () =>  ClsBowling.Roll(1);

        //    action.Should().ThrowExactly<TrowsException>().Which.MessageError.Should().Be("Only ten throws");
        //}
        
        //[Test]
        //public void when_in_ten_throw_we_have_strike_or_spare_we_can_do_another_throw(){
        //     LaunchTenThrows();

        //     ClsBowling.Roll(1);

        //    ClsBowling.Score().Should().Be(20);
        //}

        //[Test]
        //public void when_do_the_best_game_the_score_will_be_300() {
        //     LaunchTenThrowsWithStrikes();

        //     ClsBowling.Roll(10);

        //    ClsBowling.Score().Should().Be(300);
        //}
        
        //[Test]
        //public void when_do_the_best_game_unless_one_strike_the_score_will_be_270() {
        //     ClsBowling.Roll(0);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);

        //     ClsBowling.Roll(10);

        //    ClsBowling.Score().Should().Be(270);
        //}

        //private static void LaunchTenThrows(){
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(9);
        //}

        //private void LaunchTenThrowsWithOutSpareOrStrike() {
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //     ClsBowling.Roll(1);
        //}
        //private void LaunchTenThrowsWithStrikes() {
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //     ClsBowling.Roll(10);
        //}
    }
}
