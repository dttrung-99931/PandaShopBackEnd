using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using System.Collections.Generic;

namespace PandaShoppingAPI.Services
{
    public interface IRealtimeService
    {
        public void Emit(int userId, string channelName, object data);
    }
}
