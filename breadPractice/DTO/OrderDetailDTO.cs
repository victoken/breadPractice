using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace breadPractice.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public string ?CustomerName { get; set; }

        public int CustomerPhone { get; set; }

        public string ?Address { get; set; }

        public bool IsInPersonDelivery { get; set; }

        public DateTime ShipDate { get; set; }

        public DateTime? ExpectedPickupDate { get; set; }
    }
}
