using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class TurnByTurnService : TurnByTurn.TurnByTurnBase
    {
        public override async Task StartGuidance(GuidanceRequest request, IServerStreamWriter<Step> responseStream, ServerCallContext context)
        {
            var steps = new List<Step>
            {
                new Step { Direction = "Left", Road="Darrow"},
                new Step { Direction = "Left", Road="Kincaid"},
                new Step { Direction = "Right", Road = "Elm"}
            };

            foreach(var step in steps)
            {
                await Task.Delay(new Random().Next(2000, 5000));// wait two - five seconds
                await responseStream.WriteAsync(step);
            }
        }
    }
}
