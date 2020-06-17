using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class WorkRepo : GenericRepository<Work>, IWorkRepo
    {
        protected readonly MyDbContext _context;

        public WorkRepo(MyDbContext context) : base(context)
        {

        }

        public IEnumerable<Comment> GetAllComentsForJob(int? id)
        {
            return  _context.Comments.Where(p => p.Work.WorkId == id).ToList();

        }
    }
}
