using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
        public string userRoles { get; set; }
        public string token { get; set; }

        public List<User> getOneUserTesting ()
        {
            List<User> users = new List<User>()
            {
                new User{idUser = 1,firstName="Khang",lastName="Nguyễn",userName="china",userPass="1",userRoles = "Admin"}
                //new User{idUser = 2,firstName="Hello",lastName="Kitty",userName="user",userPass="pass",userRoles = "Emp"}
            };
            return users;
        }
    }
}
