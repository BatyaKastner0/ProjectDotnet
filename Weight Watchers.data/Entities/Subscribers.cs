using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Weight_Watchers.data.Entities
{
    [Table("Subscribers")]

    public class Subscribers
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(20)]

        public string firstName { get; set; }
        public string lastName { get; set; }
        [Unique]
        [RegularExpression("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})$", ErrorMessage = "the email is not valid")]
        public string email { get; set; }
        [MaxLength(10)]
        [MinLength(6)]

        public string password { get; set; }


    }
}
