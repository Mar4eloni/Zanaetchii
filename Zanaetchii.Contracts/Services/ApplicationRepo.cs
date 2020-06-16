using System;
using System.Collections.Generic;
using System.Text;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class ApplicationRepo : GenericRepository<Application>, IApplicationRepo
    {
        protected readonly MyDbContext _context;

        public ApplicationRepo(MyDbContext context) : base(context)
        {

        }
    }
}
