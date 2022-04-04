using DapperAssistant;
using ELCODE.Models;
using ELCODE.Repositories.Interfaces;

namespace ELCODE.Repositories.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientRepository : StandardRepository<Client>, IClientRepository
    {
        public ClientRepository(DbConnectionKeeper dbConnectionKeeper) : base(dbConnectionKeeper) { }
    }
}