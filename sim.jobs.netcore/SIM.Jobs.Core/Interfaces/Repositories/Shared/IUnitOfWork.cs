using System;
using System.Data;
using System.Threading.Tasks;

namespace SIM.Jobs.Core.Interfaces.Repositories.Shared
{
    public interface IUnitOfWork  : IDisposable
    {
        IDbConnection DbConnection {get;}
    }
}