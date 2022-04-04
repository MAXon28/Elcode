using DapperAssistant;
using ELCODE.Models;
using ELCODE.Repositories.Interfaces;

namespace ELCODE.Repositories.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestRepository : StandardRepository<Request>, IRequestRepository
    {
        public RequestRepository(DbConnectionKeeper dbConnectionKeeper) : base(dbConnectionKeeper) { }
    }
}