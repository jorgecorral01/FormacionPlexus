using System.Threading.Tasks;
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
            if(product.Quality > 50) { throw new GildedRoseException("The quality never can be greater than 50"); }
            return product;
        }

        private static void UpdateQuality(Product product) {
            if(product.Name == "Aged Brie") {
                product.Quality += 1;
            }else if (product.Name == "Backstage passes") {
                if (product.Sellin > 5 && product.Sellin <= 10) {
                    product.Quality += 2;
                }
                else if (product.Sellin <= 5) {
                    product.Quality += 3;
                }
                
            }
            else {
                if(product.Sellin >= 0) {
                    product.Quality -= 1;
                }
                else {
                    product.Quality -= 2;
                }
            }
        }
    }
}