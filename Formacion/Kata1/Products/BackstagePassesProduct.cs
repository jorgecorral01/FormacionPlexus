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
            if (IsSellinGreaterThan(5) && isSellinLessOrEqualThan(10)) {
                Quality += 2;
            }else if (IsSellinGreaterThan(0) && isSellinLessOrEqualThan(5)) {
                Quality += 3;
            }
            else if(Sellin == 0) {
                Quality = 0;
            }
            else {
                Quality += 1;
            }
            
        }

        private bool isSellinLessOrEqualThan(int number) {
            return Sellin <= number;
        }

        private bool IsSellinGreaterThan(int number){
            return Sellin > number;
        }
    }
}