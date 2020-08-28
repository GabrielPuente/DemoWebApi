using TurtlePizzaria.Core.Data;
using TurtlePizzaria.Domain.Entities;
using TurtlePizzaria.Infrastructure.Context;
using TurtlePizzaria.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TurtlePizzaria.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<User> _dbSet;

        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Users;
        }

        public void Post(User user)
        {
            _dbSet.Add(user);
        }

        public void Put(User user)
        {
            _dbSet.Update(user);
        }

        public void Delete(Guid id)
        {
            var obj = _dbSet.Find(id);
            obj.Active = false;
            _dbSet.Update(obj);
        }

        public User Get(Guid id)
        {
            return _dbSet.AsNoTracking().Where(x => x.Id == id && x.Active).FirstOrDefault();
        }

        public IEnumerable<User> GetList()
        {
            return _dbSet.AsNoTracking().Where(x => x.Active).ToList();
        }

        public User GetExpression(Expression<Func<User, bool>> expression)
        {
            var result = _dbSet.Where(expression);
            return result.AsNoTracking().Where(x => x.Active).FirstOrDefault();
        }
    }
}
