﻿using System;
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
        public void when_we_knocked_down_5_pins_on_the_first_roll_the_score_is_5(){
            var numberPinsKnocked = 5;
            
            ClsBowling.Roll(numberPinsKnocked);

            ClsBowling.Score().Should().Be(numberPinsKnocked);
        }

        [Test]
        public void when_in_first_throw_we_knocked_down_10_pins_and_in_the_second_throw_5_the_score_is_20(){
            var fisrtNumberPinsKnocked = 10;
            var secondNumberPinsKnocked = 5;
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
            ClsBowling.Roll(fisrtNumberPinsKnocked);
            ClsBowling.Roll(secondNumberPinsKnocked);

            ClsBowling.Roll(thirdNumberPinsKnocked);

            var expectedNumberPinsKnocked = 30;
            ClsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        }

        [Test]
        public void when_in_second_throw_we_knocked_down_all_pins_the_next_throw_sum_double() {
            var fisrtNumberPinsKnocked = 1;
            var secondNumberPinsKnocked = 9;
            var thirdNumberPinsKnocked = 5;
            ClsBowling.Roll(fisrtNumberPinsKnocked);
            ClsBowling.Roll(secondNumberPinsKnocked);

            ClsBowling.Roll(thirdNumberPinsKnocked);

            var expectedNumberPinsKnocked = 20;
            ClsBowling.Score().Should().Be(expectedNumberPinsKnocked);
        }

        [Test]
        public void when_try_do_11_throw_we_recieved_that_only_ten_times() {
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);
            ClsBowling.Roll(1);

            Func<Task> action = async () => await ClsBowling.Roll(1);

            action.Should().ThrowExactly<TrowsException>().Which.MessageError.Should().Be("Only ten throws");
        }


        [Test]
        public void when_in_ten_throw_we_have_strike_or_spare_we_can_do_another_throw(){


        }

        }
}