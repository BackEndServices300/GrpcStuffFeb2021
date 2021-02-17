using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class ProcessOrderService : ProcessOrder.ProcessOrderBase
    {
        private readonly ILogger<ProcessOrderService> _logger;

        public ProcessOrderService(ILogger<ProcessOrderService> logger)
        {
            _logger = logger;
        }

        public override async Task<OrderResponse> Process(Order request, ServerCallContext context)
        {
            _logger.LogInformation($"Got an order for {request.Id} for these items: {request.Items}");
            foreach(var item in request.Items)
            {
                await Task.Delay(1000);
                _logger.LogInformation($"Proccessing item {item} of order {request.Id}");
            }
            return new OrderResponse { Id = request.Id, PickupTime = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()) };
        }
    }
}
