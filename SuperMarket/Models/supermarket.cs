using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public class Supermarket  {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductRating { get; set; }
        public string ProductDes { get; set; }
    }
}
