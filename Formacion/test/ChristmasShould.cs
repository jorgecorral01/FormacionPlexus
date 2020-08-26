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

            christmas.ArrayLights[0, 0].Brightness.Should().Be(1);
            christmas.ArrayLights[0, 999].Brightness.Should().Be(1);
            christmas.ArrayLights[999, 0].Brightness.Should().Be(1);
            christmas.ArrayLights[999, 999].Brightness.Should().Be(1);
        }

        [Test]
        public void when_do_toggle_lights_we_have_five_hundred_with_brightness() {
            var christmas = new Christmas();

            christmas.TouggleLights();

            christmas.ArrayLights[0,0].Brightness.Should().Be(2);
            christmas.ArrayLights[1,0].Brightness.Should().Be(0);
            christmas.ArrayLights[2,0].Brightness.Should().Be(2);
            christmas.ArrayLights[3,0].Brightness.Should().Be(0);
        }

        [Test]
        public void turn_off_five_midde_lights_we_have_four_light_off() {
            var christmas = new Christmas();
            christmas.TurnOnAllLight();

            christmas.TounOffMiddleLights();

            christmas.ArrayLights[497,497].Brightness.Should().Be(1);
            christmas.ArrayLights[499,499].Brightness.Should().Be(0);
            christmas.ArrayLights[499,500].Brightness.Should().Be(0);
            christmas.ArrayLights[500,499].Brightness.Should().Be(0);
            christmas.ArrayLights[500,500].Brightness.Should().Be(0);
            christmas.ArrayLights[501,500].Brightness.Should().Be(1);
            
        }

        [Test]
        public void when_turn_off_lights_brightness_never_will_be_negative() {
            var christmas = new Christmas();

            christmas.TounOffMiddleLights();

            christmas.ArrayLights[497,0].Brightness.Should().Be(0);
            christmas.ArrayLights[498, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[499, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[500, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[501, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[502, 0].Brightness.Should().Be(0);
            christmas.ArrayLights[503, 0].Brightness.Should().Be(0);
            
        }
    }
}
