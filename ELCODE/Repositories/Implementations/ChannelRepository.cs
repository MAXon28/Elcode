using DapperAssistant;
using ELCODE.Models;
using ELCODE.Repositories.Interfaces;

namespace ELCODE.Repositories.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class ChannelRepository : StandardRepository<Channel>, IChannelRepository
    {
        public ChannelRepository(DbConnectionKeeper dbConnectionKeeper) : base(dbConnectionKeeper) { }
    }
}