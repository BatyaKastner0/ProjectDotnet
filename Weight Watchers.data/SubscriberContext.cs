using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.data.Entities;


namespace Weight_Watchers.data
{
    public class SubscriberContext : DbContext
    {
  

        public SubscriberContext(DbContextOptions<SubscriberContext> options) : base(options)
        {

        }
        
        public DbSet<Card> Cards { get; set; }
        public DbSet<Subscribers> Subscribers { get; set;}

    }
}
