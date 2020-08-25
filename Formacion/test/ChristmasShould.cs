using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Kata1;
using Kata1.Dtos;
using Kata1.Exceptions;
using NUnit.Framework;

namespace test{
    public class ChristmasShould{
        [Test]
        public void turn_on_all_lights_we_have_on_thosand_light_with_bBrightness_value_is_one(){
            var christmas = new Christmas();

            christmas.TurnOnAllLight();

            christmas.ArrayLights.Where(item => item.Brightness == 1).Should().HaveCount(1000);
        }

        [Test]
        public void turn_on_togle_lights_we_have_fifty_light_on() {
            var christmas = new Christmas();

            christmas.TougleLights();

            christmas.ArrayLights.Where(item => item.On == true).Should().HaveCount(500);
            christmas.ArrayLights[0].On.Should().Be(true);
            christmas.ArrayLights[1].On.Should().Be(false);
            christmas.ArrayLights[2].On.Should().Be(true);
            christmas.ArrayLights[3].On.Should().Be(false);
        }

        [Test]
        public void turn_off_five_midde_lights_we_have_four_light_off() {
            var christmas = new Christmas();
            christmas.TurnOnAllLight();

            christmas.TounOffMiddleLights();

            christmas.ArrayLights.Where(item => item.Brightness == 0).Should().HaveCount(5);
            christmas.ArrayLights[497].Brightness.Should().Be(1);
            christmas.ArrayLights[498].Brightness.Should().Be(0);
            christmas.ArrayLights[499].Brightness.Should().Be(0);
            christmas.ArrayLights[500].Brightness.Should().Be(0);
            christmas.ArrayLights[501].Brightness.Should().Be(0);
            christmas.ArrayLights[502].Brightness.Should().Be(0);
            christmas.ArrayLights[503].Brightness.Should().Be(1);
        }

        [Test]
        public void when_turn_off_lights_brightness_never_will_be_negative() {
            var christmas = new Christmas();

            christmas.TounOffMiddleLights();

            christmas.ArrayLights[497].Brightness.Should().Be(0);
            christmas.ArrayLights[498].Brightness.Should().Be(0);
            christmas.ArrayLights[499].Brightness.Should().Be(0);
            christmas.ArrayLights[500].Brightness.Should().Be(0);
            christmas.ArrayLights[501].Brightness.Should().Be(0);
            christmas.ArrayLights[502].Brightness.Should().Be(0);
            christmas.ArrayLights[503].Brightness.Should().Be(0);
            christmas.ArrayLights.Where(item => item.Brightness == 0).Should().HaveCount(1000);
        }
    }
}
