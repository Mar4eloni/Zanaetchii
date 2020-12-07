using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Zanaetchii.Contracts.Interfaces;
using Zanaetcii.Entities.Context;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Contracts.Services
{
    public class WorkGiverRepo : GenericRepository<WorkGiver>, IWorkGiverRepo
    {

        public WorkGiverRepo(MyDbContext context) : base(context)
        {

        }

    //    public void Add(WorkGiver entity)
    //    {
    //        _context.Add(entity);
    //    }

    //    public void AddRange(IEnumerable<WorkGiver> entities)
    //    {
    //        _context.AddRange(entities);
    //    }

    //    public WorkGiver Find(Expression<Func<WorkGiver, bool>> predicate)
    //    {
    //        return _context.Find<WorkGiver>(predicate);
    //    }

    //    public void Remove(WorkGiver entity)
    //    {
    //        _context.Remove(entity);
    //    }

    //    public void RemoveRange(IEnumerable<WorkGiver> entities)
    //    {
    //        _context.RemoveRange(entities);
    //    }

    //    public WorkGiver Update(WorkGiver entity)
    //    {
    //        _context.Update<WorkGiver>(entity);
    //        return entity;
    //    }

    //    WorkGiver IGenericRepository<WorkGiver>.Get(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    IEnumerable<WorkGiver> IGenericRepository<WorkGiver>.GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }
    }
}
