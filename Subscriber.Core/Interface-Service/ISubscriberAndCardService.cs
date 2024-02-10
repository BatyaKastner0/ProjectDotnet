using Subscriber.Core.Dto;
using Subscriber.Core.Response;
using Subscriber.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.data.Entities;

namespace Subscriber.Services
{
    public interface  ISubscriberAndCardService
    {
        public Task<BaseResponseGeneral<bool>> AddSubscriber(SubscriberDto subscriberDTO);
        public Task<BaseResponseGeneral<CardDto>> Login(string password, string email);
        public Task<BaseResponseGeneral<ClassResponse>> GetCardById(int id);

    }
}
