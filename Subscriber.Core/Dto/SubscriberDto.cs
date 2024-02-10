
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Core.Dto
{
    public class SubscriberDto { 
    public string firstName { get; set; }
    public string lastName { get; set; }
    [Unique]
        public string? email { get; set; }
    public string password { get; set; }

     public float Height { get; set; }

    }
}
