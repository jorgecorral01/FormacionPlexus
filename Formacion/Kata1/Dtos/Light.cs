namespace Kata1.Dtos{
    public class Light{
        public int Brightness;
        public bool On{ get; set; }

        public void DecreaseBrightness(){
            if (Brightness - 1 >= 0){
                Brightness = Brightness - 1;
            }
        }

        public void IncreaseBrightness(){
            Brightness = Brightness + 1;
        }
    }
}