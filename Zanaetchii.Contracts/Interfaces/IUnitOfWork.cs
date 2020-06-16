using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zanaetchii.Contracts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IWorkerRepo WorkerRepo { get; }

        Task CommitAsync();
    }
}
