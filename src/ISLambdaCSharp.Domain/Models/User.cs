using System;
using System.Collections.Generic;
using System.Text;

namespace ISLambdaCSharp.Domain.Models
{
    public class User
    {
        public bool Active { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public GamePlatform Platform { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public User()
        {
            Id = -1;
            Active = false;
        }
    }
}
