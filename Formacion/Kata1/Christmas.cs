using System.Collections.Generic;
using System.Linq;
using Kata1.Dtos;

namespace Kata1{
    public class Christmas{
        public Light[,] ArrayLights { get; set; }

        public Christmas(){
            ArrayLights = new Light[1000,1000];
            for (var i = 0; i < 1000; i++){
                for (var j = 0; j < 1000; j++){
                    ArrayLights[i,j] = new Light{On = false, Brightness = 0};
                }
            }
        }
        public void TurnOnAllLight(){
            for(var i = 0;i < 1000;i++) {
                for(var j = 0;j < 1000;j++) {
                    ArrayLights[i, j].IncreaseBrightness();
                }
            }
        }


        public void TouggleLights(){
            for(var i = 0;i < 1000;i++) {
                for(var j = 0;j < 1000;j++) {
                    if(i % 2 == 0) {
                        ArrayLights[i, j].Toggle();
                    }
                }
            }
        }

        public void TounOffMiddleLights(){
            for(var i = 0;i < 1000;i++) {
                for(var j = 0;j < 1000;j++) {
                    if ((i == 499 && j == 499) || (i == 499 && j == 500) || (i == 500 && j == 499) || (i == 500 && j == 500)) {
                        ArrayLights[i, j].DecreaseBrightness();
                    }
                }
            }
        }
    }
}