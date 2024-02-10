using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Core.Dto
{
    public class CardDto
    {

        public int Id { get; set; }
        public DateTime UpDate { get; set; }
        public float BMI { get; set; } = 0;
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
