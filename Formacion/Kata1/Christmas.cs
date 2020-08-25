using System.Collections.Generic;
using System.Linq;
using Kata1.Dtos;

namespace Kata1{
    public class Christmas{
        public List<Light> ArrayLights { get; set; }

        public Christmas(){
            ArrayLights = new List<Light>();
            for (int i = 0; i < 1000; i++){
                ArrayLights.Add(new Light{On = false, Brightness = 0});
            }
        }
        public void TurnOnAllLight(){
            var i = 0;
            foreach(var light in ArrayLights) {
                light.IncreaseBrightness();
                i++;
            }
        }


        public void TougleLights(){
            var i = 0;
            foreach (var light in ArrayLights){
                if (i % 2 == 0){
                    light.On = !light.On ;
                }
                i++;
            }
        }

        public void TounOffMiddleLights(){
            var i = 0;
            foreach(var light in ArrayLights) {
                if(i >= 498 && i <= 502 ) {
                    light.DecreaseBrightness();
                }
                i++;
            }
        }
    }
}