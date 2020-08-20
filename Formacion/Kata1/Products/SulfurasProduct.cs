using Kata1.Exceptions;

namespace Kata1.Products{
    public class SulfurasProduct: ProductAbstract.ProductAbstract{
        public override void UpdateProduct(){
            if (Quality != 80){throw new GildedRoseException("The quality Sulfuras always 80");}
        }

        public override void UpdateSellin(){
            
        }

        public override void UpdateQuality(){
            
        }
    }
}