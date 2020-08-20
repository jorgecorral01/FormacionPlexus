using Kata1.Exceptions;

namespace Kata1.Products{
    public class SulfurasProduct: ProductAbstract.ProductAbstract{
        public override void UpdateProduct(){
            if (IsQualityDiferentTo(80)){throw new GildedRoseException("The quality Sulfuras always 80");}
        }

        private bool IsQualityDiferentTo(int number){
            return Quality != number;
        }

        public override void UpdateSellin(){
            
        }

        public override void UpdateQuality(){
            
        }
    }
}