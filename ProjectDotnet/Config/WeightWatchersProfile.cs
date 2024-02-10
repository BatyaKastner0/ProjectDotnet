using AutoMapper;
using Subscriber.Core.Dto;
using Subscriber.Core.Response;
using System.Runtime.Intrinsics.X86;
using Weight_Watchers.data.Entities;

namespace Subscriber.WebApi.Config
{
    public class WeightWatchersProfile:Profile
    {

        public WeightWatchersProfile()
        {
            CreateMap<CardDto, Card>().ReverseMap();
            CreateMap<Subscribers, SubscriberDto>().ForMember(dest => dest.Height, opt => opt.Ignore()).ReverseMap();//ברצוני שיהיה מבלי הגובה
            CreateMap<BaseResponseGeneral<Card>, BaseResponseGeneral<CardDto>>();

        }
    }
}
