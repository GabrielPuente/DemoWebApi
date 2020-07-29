using Demo.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Demo.Service.Interfaces
{
    public interface IUserService
    {
        User Post(User user);
        User Put(User user);
        void Delete(Guid id);
        User Get(Guid id);
        IEnumerable<User> GetList();
        User GetByEmail(string email);
    }
}
