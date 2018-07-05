using ISLambdaCSharp.Domain.Interfaces;
using ISLambdaCSharp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ISLambdaCSharp.TestDAL.Repos
{
    public class TestUserRepo : IEntityRepo<User>
    {
        List<User> userDB = new List<User>();
        public void Add(User entity)
        {
            entity.Id = userDB.Count+1;
            var now= DateTime.Now;
            entity.Created = now;
            entity.LastModified = now;
            userDB.Add(((MockUser)entity).Clone());
        }

        public void Delete(User entity)
        {
            userDB.Remove(userDB.FirstOrDefault(u => u.Id == entity.Id));
        }

        public List<User> GetAll()
        {
            return userDB;
        }

        public User GetById(int id)
        {
            return userDB[id - 1];
        }

        public User GetByName(string name)
        {
            return userDB.FirstOrDefault(u => u.Name == name);
        }

        public void UpdateEntity(User entity)
        {
            userDB.Remove(userDB.FirstOrDefault(e => e.Name == entity.Name));
            entity.LastModified = DateTime.Now;
            userDB.Add(((MockUser)entity).Clone());
        }
    }

    public class MockUser : User
    {
        public MockUser Clone()
        {
            return (MockUser)this.MemberwiseClone();
        }
    }
}
