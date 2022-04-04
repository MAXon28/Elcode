using DapperAssistant;
using ELCODE.Models;
using ELCODE.Repositories.Interfaces;

namespace ELCODE.Repositories.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestCriteriaRepository : StandardRepository<RequestCriteria>, IRequestCriteriaRepository
    {
        public RequestCriteriaRepository(DbConnectionKeeper dbConnectionKeeper) : base(dbConnectionKeeper) { }
    }
}