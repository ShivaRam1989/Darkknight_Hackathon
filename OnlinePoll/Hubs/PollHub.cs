using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlinePoll.Models;

namespace OnlinePoll.Hubs
{
    [Microsoft.AspNet.SignalR.Hubs.HubName("pollHub")]
    public class PollHub: Microsoft.AspNet.SignalR.Hub
    {
        public void Broadcast()
        {
            var BalletInstance = BalletBox.Instance;
            Clients.All.broadcastMessage(BalletInstance.DcVotingCount, BalletInstance.MarvelVotingCount, BalletInstance.DcVotingPercent,BalletInstance.MarvelVotingPercent);
        }
    }
}