using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string user_location { get; set; }
        public string user_rate { get; set; }
        public string user_comment { get; set; }


    }
}
