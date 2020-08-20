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
            if (Sellin > 5 && Sellin <= 10) {
                Quality += 2;
            }else if (Sellin <= 5){
                Quality += 3;
            }
            else {
                Quality += 1;
            }
            
        }
    }
}