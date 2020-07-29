using Demo.Core.Util;
using Demo.Domain.Entities;
using Demo.Infrastructure.Data.Interfaces;
using Demo.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Demo.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Post(User user)
        {
            user.Password = Password.PasswordHash(user.Password);
            _userRepository.Post(user);
            _userRepository.UnitOfWork.Commit();
            return user;
        }

        public User Put(User user)
        {
            _userRepository.Put(user);
            _userRepository.UnitOfWork.Commit();
            return user;
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
            _userRepository.UnitOfWork.Commit();
        }

        public User Get(Guid id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetList()
        {
            return _userRepository.GetList();
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetExpression(x => x.Email == email);
        }
    }
}
