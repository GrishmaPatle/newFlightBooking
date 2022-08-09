using FlightRes.RabbitMQ;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRes.User.Service.Consumer
{
    public class AddedAirlinesConsume : IConsumer<RabbitMqModel>
    {
        public  async Task Consume(ConsumeContext<RabbitMqModel> context)
        {
            await Task.Run(() => { var obj = context.Message; });
           
        }
    }
    
}
