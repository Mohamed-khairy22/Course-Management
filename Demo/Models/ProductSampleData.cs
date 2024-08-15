namespace Demo.Models
{
    public class ProductSampleData
    {
        List<Product> products;
        public ProductSampleData()
        {
            products = new List<Product>();
            products.Add(new Product() {Id=1 ,Name="IPhone",Price=50000,Images="1.jpeg",Description="IPhone13" });
            products.Add(new Product() { Id = 2, Name = "IPhone", Price = 20000, Images = "2.jpeg", Description = "IPhoneX" });
            products.Add(new Product() { Id = 3, Name = "IPhone", Price = 30000, Images = "3.jpeg", Description = "IPhone12" });

        }
        public List<Product> GetAll()
        {
            return products;
        }
        public Product GetById (int id)
        { 
        return products.FirstOrDefault(p=>p.Id==id);
        }
    }
}
