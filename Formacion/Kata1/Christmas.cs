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
            ArrayLights = ArrayLights.Select(item => new Light{Brightness = item.Brightness + 1}).ToList();
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
                    if (light.Brightness - 1 >= 0){
                        light.Brightness = light.Brightness - 1;
                    }
                }
                i++;
            }
        }
    }
}