using Kata1.Dtos;

namespace Kata1{
    public class GildedRose
    {
        public Product UpdateProduct(Product product){
            product.Sellin -= 1;
            if (product.Sellin >= 0){
                product.Quality -= 1;
            }
            else{
                product.Quality -= 2;
            }
            return product;
        }
    }
}