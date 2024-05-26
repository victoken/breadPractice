namespace breadPractice.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ?ProductName { get; set; }

        public int CategoryID { get; set; }

        public string ?ProductUnit { get; set; }

        public string ?ProductDescription { get; set; }

        public int OriginalPrice { get; set; }

        public int Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsAvailable { get; set; }
    }
}
