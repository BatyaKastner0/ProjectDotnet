using Microsoft.EntityFrameworkCore;
using Subscriber.Core.Dto;
using Subscriber.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.data;
using Weight_Watchers.data.Entities;
using static Subscriber.DAL.SubscriberAndCardRepository;
namespace Subscriber.DAL
{
    public class SubscriberAndCardRepository : ISubscriberAndCardRepository
    {
        readonly SubscriberContext _SubscriberContext;

        public SubscriberAndCardRepository(SubscriberContext subscriberContext)
        {
            _SubscriberContext = subscriberContext;
        }

        public async Task<BaseResponseGeneral<bool>> AddSubscriber(Subscribers subscriber, float height)
        {
            try
            {
                BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();


                var sub = await _SubscriberContext.Subscribers.AddAsync(subscriber);
                await _SubscriberContext.SaveChangesAsync();
                var defaultCard = new Card
                {
                    subscriberId = sub.Entity.Id,
                    openDate = DateTime.Now,
                    updateDate = DateTime.Now,
                    bmi = 0,
                    height = height
                };
                _SubscriberContext.Cards.AddAsync(defaultCard);
                await _SubscriberContext.SaveChangesAsync();
                response.succsed = true;
                response.Response = true;
                response.message = " added successfuly";


                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("Register Failed");
            }

        } 
        public async Task<BaseResponseGeneral<Card>> Login(string password, string email)
        {
            try
            {
                Subscribers subscriber = _SubscriberContext.Subscribers.Where(t => t.email == email && t.password == password).FirstOrDefault();
                BaseResponseGeneral<Card> response = new BaseResponseGeneral<Card>();
                if (subscriber != null)
                {
                    response.Response = _SubscriberContext.Cards.Where(t => t.subscriberId == subscriber.Id).FirstOrDefault();
                    response.succsed = true;
                    response.message = "you recognized";
                }
                else
                {
                    response.Response = null;
                    response.message = "the password or email does`nt exist";
                }
                return response;
            }

            catch (Exception ex)
            {
                throw new Exception("error:login failed");
            }
        }
        public async Task<BaseResponseGeneral<ClassResponse>> GetCardById(int id)
        {
            try
            {
                Card card = _SubscriberContext.Cards.Where(p => p.id == id).FirstOrDefault();
                BaseResponseGeneral<ClassResponse> response = new BaseResponseGeneral<ClassResponse>();
                if (card != null)
                {
                    Subscribers subscriber = _SubscriberContext.Subscribers.Where(t => t.Id == card.subscriberId).FirstOrDefault();
                    if (subscriber != null)
                    {
                        response.Response = new ClassResponse(id, card.height, card.weight, card.bmi, subscriber.firstName, subscriber.lastName);
                        response.succsed = true;
                        response.message = "succedd";
                    }
                    else
                    {
                        response.succsed = false;
                        response.message = "failed";
                    }

                }
                else
                {
                    response.succsed = false;
                    response.message = "card doesnt found";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("error:geting card failed");
            }
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _SubscriberContext.Subscribers.AnyAsync(s => s.email == email);
        }
    }
}
