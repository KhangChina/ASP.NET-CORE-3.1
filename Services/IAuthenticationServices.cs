using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IAuthenticationServices
    {
       public User Autheticate(string userName, string passWord);
    }
}
