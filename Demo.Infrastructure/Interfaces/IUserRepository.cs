using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Demo.Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository
    {
        void Post(User user);
        void Put(User user);
        void Delete(Guid id);
        User Get(Guid id);
        IEnumerable<User> GetList();
        User GetExpression(Expression<Func<User, bool>> expression);
    }
}
