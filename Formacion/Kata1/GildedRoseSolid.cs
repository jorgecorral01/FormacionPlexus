using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Kata1.Dtos;
using Kata1.Exceptions;
using Kata1.Products.ProductAbstract;

namespace Kata1 {
    public class GildedRoseSolid {
        public async Task<ProductAbstract> UpdateProduct(ProductAbstract product) {
            await Task.Delay(1);
            product.UpdateSellin();
            product.UpdateQuality();
            return product;
        }

        private static void UpdateQuality(ProductAbstract product) {
            if(IsAgedBrie(product.Name) || (IsBackstagePasses(product.Name) && IsSellingGreaterThan(product.Sellin,10))) {
                UpdateQuality(product, 1);
            }else if (IsBackstagePasses(product.Name)) {
                if (IsSellingGreaterThan(product.Sellin, 5) && product.Sellin <= 10) {
                    UpdateQuality(product, 2);
                }
                else if (IsSellingGreaterThan(product.Sellin, 0) && product.Sellin <= 5) {
                    UpdateQuality(product, 3);
                }
                else{
                    product.Quality = 0;
                }
            }
            else {
                if(product.Sellin >= 0 && !IsConjured(product.Name)) {
                    UpdateQuality(product, -1);
                }
                else {
                    UpdateQuality(product, -2);
                }
            }
        }

        private static bool IsSellingGreaterThan(int sellin, int number){
            return sellin > number;
        }

        private static bool IsConjured(string name){
            return name == "Conjured";
        }

        private static void UpdateQuality(ProductAbstract product, int productQualityIncrease){
            product.Quality += productQualityIncrease;
        }

        private static bool IsAgedBrie(string name) {
            return name == "Aged Brie";
        }

        private static bool IsBackstagePasses(string name){
            return name == "Backstage passes";
        }
    }
}