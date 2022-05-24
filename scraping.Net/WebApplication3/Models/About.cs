using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class About
    {
        [Key]
        public int id { get; set; }

        public string headernames { get; set; }
   
        public string location { get; set; }
     
        public string phone { get; set; }

        public string reviews_rate { get; set; }
        public string reviews_c { get; set; }
    }
}
