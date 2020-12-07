using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class WorkerRepo : GenericRepository<Worker>, IWorkerRepo
    {

        public WorkerRepo(MyDbContext context) : base(context)
        {
            
        }
       
    }
}
