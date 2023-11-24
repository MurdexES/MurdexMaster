namespace MinimalAPI.Model
{
    public class Product
    {
        public Product(string productName, string productDescription, float productPrice, int productCount) 
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            ProductCount = productCount;
        }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int ProductCount { get; set; }
    }
}
