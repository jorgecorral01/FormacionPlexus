using System;
using Kata1.Exceptions;

namespace Kata1.Products{
    public class AgedBrieProduct : ProductAbstract.ProductAbstract{
        public override void UpdateProduct(){
            UpdateSellin();
            UpdateQuality();
            if(Quality > 50) { throw new GildedRoseException("The quality never can be greater than 50"); }
        }

        public override void UpdateSellin(){
            Sellin -= 1;
        }

        public override void UpdateQuality(){
            Quality += 1;
        }
    }
}