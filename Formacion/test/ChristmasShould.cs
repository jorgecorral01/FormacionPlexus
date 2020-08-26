using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using Kata1.Exceptions;
using NUnit.Framework;

namespace test {
    public class ChristmasShould {
        [Test]
        public void turn_on_all_lights_we_have_on_thosand_light_with_bBrightness_value_is_one() {
            var christmas = new Christmas();

            christmas.TurnOnAllLight();

            christmas.ArrayLights[0, 0].Brightness.Should().Be(1);
            christmas.ArrayLights[0, 999].Brightness.Should().Be(1);
            christmas.ArrayLights[999, 0].Brightness.Should().Be(1);
            christmas.ArrayLights[999, 999].Brightness.Should().Be(1);
        }

        [Test]
        public void when_do_toggle_lights_in_first_line_we_have_toggle_lights_in_first_line() {
            var christmas = new Christmas();

            christmas.TouggleLights();

            christmas.ArrayLights[0, 0].Brightness.Should().Be(2);
            christmas.ArrayLights[1, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[2, 0].Brightness.Should().Be(2);
            christmas.ArrayLights[3, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[0, 1].Brightness.Should().Be(0);
            christmas.ArrayLights[1, 1].Brightness.Should().Be(0);
            christmas.ArrayLights[2, 1].Brightness.Should().Be(0);
            christmas.ArrayLights[3, 1].Brightness.Should().Be(0);
        }

        [Test]
        public void turn_off_five_midde_lights_we_have_four_light_off() {
            var christmas = new Christmas();
            christmas.TurnOnAllLight();

            christmas.TurnOffMiddleLights();

            christmas.ArrayLights[497, 497].Brightness.Should().Be(1);
            christmas.ArrayLights[499, 499].Brightness.Should().Be(0);
            christmas.ArrayLights[499, 500].Brightness.Should().Be(0);
            christmas.ArrayLights[500, 499].Brightness.Should().Be(0);
            christmas.ArrayLights[500, 500].Brightness.Should().Be(0);
            christmas.ArrayLights[501, 500].Brightness.Should().Be(1);

        }

        [Test]
        public void when_turn_off_lights_brightness_never_will_be_negative() {
            var christmas = new Christmas();

            christmas.TurnOffMiddleLights();

            christmas.ArrayLights[497, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[498, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[499, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[500, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[501, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[502, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[503, 0].Brightness.Should().Be(0);

        }

        [Test]
        public void when_use_all_options_of_part_two_first_light_have_brightness_one() {
            var christmas = new Christmas();

            christmas.TurnOnAllLight();
            christmas.TouggleLights();
            christmas.TurnOffMiddleLights();

            //TODO I think [0,0] should have 3 in Brightness value 
            christmas.ArrayLights[0, 0].Brightness.Should().Be(1);
            christmas.ArrayLights[1, 0].Brightness.Should().Be(1);
        }

        [Test]
        public void toggle_one_time_would_increase_the_total_brightness_by_1000() {
            var christmas = new Christmas();

            christmas.TouggleLights();

            var totalBrightness = 0;
            for(var i = 0;i < 1000;i++) {
                for(var j = 0;j < 1000;j++) {
                    totalBrightness += christmas.ArrayLights[i, j].Brightness;
                }
            }
            totalBrightness.Should().Be(1000);
        }

        [Test]
        public void toggle_thosand_times_would_increase_the_total_brightness_by_1000000() {
            var christmas = new Christmas();

            for(var i = 0;i < 1000;i++) {
                //for(var j = 0;j < 1000;j++) {
                christmas.TouggleLights();
                //}
            }

            var totalBrightness = 0;
            for(var i = 0;i < 1000;i++) {
                for(var j = 0;j < 1000;j++) {
                    totalBrightness += christmas.ArrayLights[i, j].Brightness;
                }
            }

            totalBrightness.Should().Be(1000000);
        }

        [Test]
        public void toggle_zero_zero_to_999_999_would_increase_the_total_brightness_by_2000000() {
            var christmas = new Christmas();

            for(var i = 0;i < 1000;i++) {
                for(var j = 0;j < 1000;j++) {
                    christmas.TouggleLights();
                }
            }

            var totalBrightness = 0;
            for(var i = 0;i < 1000;i++) {
                for(var j = 0;j < 1000;j++) {
                    totalBrightness += christmas.ArrayLights[i, j].Brightness;
                }
            }

            totalBrightness.Should().Be(2000000);
        }


    }
}
