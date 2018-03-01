using Panel.Models;
using System.Collections.Generic;

namespace Panel.IService
{
    public interface IUserService
    {
        void UserAdded(User model);
        IList<User> UserList();
    }
}