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
        public WorkRepo(MyDbContext context) : base(context)
        {

        }

        public IEnumerable<Comment> GetAllComentsForJob(int? id)
        {
            return  _context.Comments.Where(p => p.Work.WorkId == id).ToList();

        }

        public IEnumerable<Work> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }

        public Work GetJobById(int id)
        {
            return _context.Jobs.Where<Work>(p => p.WorkId == id).FirstOrDefault();
        }
    }
}
