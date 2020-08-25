namespace Kata1.Dtos{
    public class Light{
        public int Brightness;
        public bool On{ get; set; }

        public void DecreaseBrightness(){
            Brightness = Brightness - 1;
        }
    }
}