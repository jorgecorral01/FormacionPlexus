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
        public void turn_on_all_lights_we_have_thousand_light_on(){
            var christmas = new Christmas();

            christmas.TurOnAllLight();

            christmas.ArrayLights.Where(item => item.On == true).Should().HaveCount(1000);
        }
    }
}
