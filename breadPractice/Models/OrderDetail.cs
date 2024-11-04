
namespace breadPractice.Models
{
    /// <summary>
    /// 訂單
    /// </summary>
    public class OrderDetail
    {
        public int OrderDetailID{ get; set; }
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public int CustomerPhone { get; set; }

        public string Address { get; set; }

        public bool IsInPersonDelivery { get; set; }

        public DateTime ShipDate { get; set; }

        public DateTime? ExpectedPickupDate { get; set; }
    }
}
