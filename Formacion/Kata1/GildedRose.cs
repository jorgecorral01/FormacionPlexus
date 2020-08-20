using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Kata1.Dtos;
using Kata1.Exceptions;

namespace Kata1 {
    public class GildedRose {
        public async Task<Product> UpdateProduct(Product product) {
            await Task.Delay(1);
            if(product.Name != "Sulfuras") {
                product.Sellin -= 1;
                UpdateQuality(product);
            }

            if(product.Quality < 0) { throw new GildedRoseException("The quality never can be negative"); }
            if(product.Quality > 50 && product.Name != "Sulfuras") { throw new GildedRoseException("The quality never can be greater than 50"); }
            if(product.Quality != 80 && product.Name == "Sulfuras" ) { throw new GildedRoseException("The quality Sulfuras always 80"); }
            return product;
        }

        private static void UpdateQuality(Product product) {
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

        private static void UpdateQuality(Product product, int productQualityIncrease){
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