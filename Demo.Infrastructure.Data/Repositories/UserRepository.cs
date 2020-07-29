using Demo.Core.Data;
using Demo.Domain.Entities;
using Demo.Infrastructure.Data.Context;
using Demo.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Users;
        }

        public IUnitOfWork UnitOfWork => _context;

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
            return _dbSet.AsNoTracking().Where(u => u.Id == id && u.Active).FirstOrDefault();
        }

        public IEnumerable<User> GetList()
        {
            return _dbSet.AsNoTracking().Where(u => u.Active).ToList();
        }

        public User GetExpression(Expression<Func<User, bool>> expression)
        {
            var result = _dbSet.Where(expression);
            return result.AsNoTracking().Where(x => x.Active).FirstOrDefault();
        }
    }
}
