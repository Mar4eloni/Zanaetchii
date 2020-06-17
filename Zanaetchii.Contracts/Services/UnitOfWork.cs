using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;

namespace Zanaetchii.Contracts.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        private IWorkerRepo _workerRepo;

        public IWorkerRepo WorkerRepo
        { 
            get { 
                if (_workerRepo == null)
                {
                    //_workerRepo = new WorkerRepo(_context, this);
                }
                return _workerRepo;
            } 
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
        public UnitOfWork()
        {
            _context = new MyDbContext();
        }
    }
}
