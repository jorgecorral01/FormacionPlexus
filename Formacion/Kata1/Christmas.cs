using System.Collections.Generic;
using System.Linq;
using Kata1.Dtos;

namespace Kata1{
    public class Christmas{
        public List<Light> ArrayLights { get; set; }

        public Christmas(){
            ArrayLights = new List<Light>();
            for (int i = 0; i < 1000; i++){
                ArrayLights.Add(new Light{On = false});
            }
        }
        public void TurOnAllLight(){
            ArrayLights = ArrayLights.Select(item => new Light{On = true}).ToList();
        }

        
    }
}