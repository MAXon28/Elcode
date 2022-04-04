using DapperAssistant;
using ELCODE.Models;
using ELCODE.Repositories.Interfaces;

namespace ELCODE.Repositories.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestTypeRepository : StandardRepository<RequestType>, IRequestTypeRepository
    {
        public RequestTypeRepository(DbConnectionKeeper dbConnectionKeeper) : base(dbConnectionKeeper) { }
    }
}