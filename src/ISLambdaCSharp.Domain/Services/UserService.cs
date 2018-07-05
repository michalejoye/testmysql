using ISLambdaCSharp.Domain.Interfaces;
using ISLambdaCSharp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISLambdaCSharp.Domain
{
    public class UserService : IUserService
    {
        private IEntityRepo<User> _repo;

        public UserService(IEntityRepo<User> repo)
        {
            _repo = repo;
        }

        public void AddUser(User user)
        {
            if(!IsUserPresent(user.Name))
            {
                _repo.Add(user);
            }
            else
            {
                throw new Exception();
            }
        }

        public void DeleteUserByName(string name)
        {
            if (IsUserPresent(name))
            {
                _repo.Delete(_repo.GetByName(name));
            }
            else
            {
                throw new Exception();
            }
            
        }

        public User GetUser(string userName)
        {
            return _repo.GetByName(userName);
        }

        public List<User> GetUsers()
        {
            return this._repo.GetAll();

        }

        public void UpdateUser(User user)
        {
            var userInDB = GetUserById(user.Id);
            if (userInDB.Name == user.Name)
                this._repo.UpdateEntity(user);
            else
                throw new Exception();
        }
        private bool IsUserPresent(string name)
        {
            return GetUser(name) != null;
        }
        private User GetUserById(int id)
        {
            return _repo.GetById(id);
        }

        
    }
}
