using Subscriber.Core.Dto;
using Subscriber.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.data.Entities;

namespace Subscriber.DAL
{
    public interface ISubscriberAndCardRepository

    {
     public Task<BaseResponseGeneral<bool>> AddSubscriber(Subscribers subscriber, float height);
     public Task<BaseResponseGeneral<Card>> Login(string password, string email);
     public Task<BaseResponseGeneral<ClassResponse>> GetCardById(int id);
     public Task<bool> EmailExists(string email);
    }
}
