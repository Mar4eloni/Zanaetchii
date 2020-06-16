using System;
using System.Collections.Generic;
using System.Text;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class WorkGiverRepo : GenericRepository<WorkGiver>, IWorkerRepo
    {
        protected readonly MyDbContext _context;

        public WorkGiverRepo(MyDbContext context) : base(context)
        {

        }
    }
}
