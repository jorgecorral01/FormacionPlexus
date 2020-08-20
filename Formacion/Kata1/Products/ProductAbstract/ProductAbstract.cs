using System.Threading.Tasks;

namespace Kata1.Products.ProductAbstract{
    public abstract class ProductAbstract {
        public int Sellin{ get; set; }
        public int Quality{ get; set; }
        public string Name{ get; set; }
        public abstract void UpdateProduct();
        public abstract void UpdateSellin();
        public abstract void UpdateQuality();
    }
}