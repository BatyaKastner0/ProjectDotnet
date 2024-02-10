using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.data.Entities;

namespace Weight_Watchers.data.Entities
{ [Table("Card")]
    public class Card
    {
       
                [Key]
                [Required]
                public int id { get; set; }
                public DateTime openDate { get; set; }

                public float bmi { get; set; }
                public float height { get; set; }
                public float weight { get; set; }
                public DateTime updateDate { get; set; }
                public int? subscriberId { get; set; }

                [ForeignKey(nameof(subscriberId))]
                public Subscribers subscriberOfCard { get; set; }

                
            }

        
    
}
