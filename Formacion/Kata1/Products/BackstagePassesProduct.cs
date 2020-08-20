namespace Kata1.Products{
    public class BackstagePassesProduct:ProductAbstract.ProductAbstract{
        public override void UpdateProduct(){
           UpdateSellin();
           UpdateQuality();
        }

        public override void UpdateSellin(){
            Sellin -= 1;
        }

        public override void UpdateQuality(){
            Quality += 1;
        }
    }
}