using Subscriber.Core.Dto;
using Subscriber.DAL;
using Subscriber.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Weight_Watchers.data.Entities;
using System.Text.RegularExpressions;

namespace Subscriber.Services
{
    public class SubscriberAndCardService:ISubscriberAndCardService
    {
        readonly ISubscriberAndCardRepository _Repository;
        readonly IMapper _mapper;
        public SubscriberAndCardService(ISubscriberAndCardRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneral<bool>> AddSubscriber(SubscriberDto subscriberDTO)
        {
            BaseResponseGeneral<bool> resonse = new BaseResponseGeneral<bool>();
            if (await _Repository.EmailExists(subscriberDTO.email))
            {
                resonse.Response = false;
                resonse.succsed = false;
                resonse.message = "email already exists";
            }
            else
            resonse = await _Repository.AddSubscriber(_mapper.Map<Subscribers>(subscriberDTO), subscriberDTO.Height);
           
            return resonse;
        }
        public async Task<BaseResponseGeneral<CardDto>> Login(string password, string email)
        {
            BaseResponseGeneral<Card> response = await _Repository.Login(password, email);

            if (!IsValidEmail(email) || !IsValidPassword(password))
            {

                response.Response = null;
                response.succsed = false;
                response.message = "invalid email or password";
            }
            return _mapper.Map<BaseResponseGeneral<CardDto>>(response);

        }

        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);





        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        }






        public async Task<BaseResponseGeneral<ClassResponse>> GetCardById(int id)
        {
            return await _Repository.GetCardById(id);

        }
    }
}




