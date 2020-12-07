using System;
using System.Collections.Generic;
using System.Text;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Interfaces
{
    public interface IWorkRepo : IGenericRepository<Work>
    {
        IEnumerable<Comment> GetAllComentsForJob(int? id);

        IEnumerable<Work> GetAllJobs();

        Work GetJobById(int id);
    }
}
