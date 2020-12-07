using System;
using System.Collections.Generic;
using System.Text;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class RatingsRepo : GenericRepository<Rating>, IRatingsRepo
    {

        public RatingsRepo(MyDbContext context) : base(context)
        {

        }
    }
}
