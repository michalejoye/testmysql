using ISLambdaCSharp.Domain.Models;
using System.Collections.Generic;

namespace ISLambdaCSharp.Domain
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(string userName);

        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUserByName(string name);
    }
}