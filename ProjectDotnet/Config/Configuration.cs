

using AutoMapper;
using Subscriber.DAL;
using Subscriber.Services;

namespace Subscriber.WebApi.Config
{

    public static class Configuration
    {
        public static void Configurations(this IServiceCollection services)
        {
            services.AddScoped<ISubscriberAndCardService, SubscriberAndCardService>();
            services.AddScoped<ISubscriberAndCardRepository, SubscriberAndCardRepository>();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WeightWatchersProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


        }


    }
}











