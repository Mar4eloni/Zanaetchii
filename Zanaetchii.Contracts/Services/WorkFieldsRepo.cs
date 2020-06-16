using System;
using System.Collections.Generic;
using System.Text;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class WorkFieldsRepo : GenericRepository<WorkField>, IWorkFieldsRepo
    {
        protected readonly MyDbContext _context;

        public WorkFieldsRepo(MyDbContext context) : base(context)
        {

        }
    }
}
