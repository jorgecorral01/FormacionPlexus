using System;
using Kata1.Dtos;

namespace Kata1{
    public class GildedRose
    {
        public Product UpdateProduct(DateTime actualdate, Product product){
            if (product.Sellin > actualdate){
                product.Quality -= 1;
            }

            return product;
        }
    }
}