using System.Threading.Tasks;
using Kata1.Dtos;
using Kata1.Exceptions;

namespace Kata1.Products {
    public class AnyProduct : ProductAbstract.ProductAbstract {
        //public override async Task UpdateProduct(){
        public override void UpdateProduct() {
            //await Task.Delay(1);
            DecreaseSellin();
            DecreaseQuality();
        }

        public override void DecreaseSellin() {
            Sellin -= 1;
        }

        public override void DecreaseQuality() {
            if(Sellin < 0) {
                Quality -= 2;
            }
            else {
                Quality -= 1;
            }
            if (Quality < 0) {throw new GildedRoseException("The quality never can be negative");}
        }
    }
}