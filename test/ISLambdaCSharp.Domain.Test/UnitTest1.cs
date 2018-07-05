using FluentAssertions;
using ISLambdaCSharp.Domain.Interfaces;
using ISLambdaCSharp.Domain.Models;
using ISLambdaCSharp.TestDAL.Repos;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace ISLambdaCSharp.Domain.Test
{
    public class UnitTest1
    {
        private UserService us;
        private String userName1 = "mjoye";
        private MockUser user1;


        [Fact]
        public void GetListUser()
        {
            SetUpUserService();
            List<User> users = us.GetUsers();
            users.Should().NotBeNull();
            users.Count.Should().Be(1);
        }
        [Fact]
        public void GetAUser()
        {
            SetUpUserService();
            MockUser user = (MockUser)us.GetUser(userName1);
            user.Should().NotBeNull();
        }

        [Fact]
        public void AddUser()
        {
            SetUpUserService();
            UserIDShould(user1, 1);
            us.GetUsers().Count.Should().Be(1);
        }

        [Fact]
        public void AddSameUser()
        {
            SetUpUserService();
            UserIDShould(user1, 1);
            us.GetUsers().Count.Should().Be(1);
            RunMethodToThrowExeption(us, "AddUser", user1);
        }

        [Fact]
        public void AddTwoUser()
        {
            SetUpUserService();
            UserIDShould(user1,1);
            us.GetUsers().Count.Should().Be(1);
            User user2 = AddUserToDB("mtest");
            UserIDShould(user2, 2);
            us.GetUsers().Count.Should().Be(2);
        }

        [Fact]
        public void UpdateUser()
        {
            SetUpUserService();
            user1.Active = true;
            us.UpdateUser(user1);
            user1.LastModified.Should().NotBe(user1.Created);
            user1.Name = "t";
            RunMethodToThrowExeption(us, "UpdateUser", user1);
        }
        [Fact]
        public void DeleteUser()
        {
            SetUpUserService();
            us.DeleteUserByName(userName1);
            us.GetUser(userName1).Should().BeNull();
        }

        public void AddFriendToUser()
        {
            SetUpUserService();

        }

        private void RunMethodToThrowExeption(object obj,string MethodName, params object[] param)
        {
            Action action = () =>
            {
                Type thisType = obj.GetType();
                MethodInfo theMethod = thisType.GetMethod(MethodName);
                theMethod.Invoke(obj, param);
            };
            action.Should().Throw<Exception>();
        }
       

        private void UserIDShould(User user,int id)
        {
            user.Id.Should().Be(id);
        }

        internal void SetUpUserService()
        {
            us = new UserService((IEntityRepo<User>) new TestUserRepo());
            user1 = AddUserToDB(userName1);
        }


        internal MockUser AddUserToDB(string Name)
        {

            MockUser user = CreateUser(Name);
            us.AddUser(user);
            return user;
        }

        private static MockUser CreateUser(string userName)
        {
            MockUser user = new MockUser();
            user.Name = userName;
            user.Platform = GamePlatform.PS4 | GamePlatform.PC;
            return user;
        }

    }
}
