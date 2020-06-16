using System;
using System.Collections.Generic;
using System.Text;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class CommentsRepo : GenericRepository<Comment>, ICommentsRepo
    {
        protected readonly MyDbContext _context;

        public CommentsRepo(MyDbContext context) : base(context)
        {

        }
    }
}
