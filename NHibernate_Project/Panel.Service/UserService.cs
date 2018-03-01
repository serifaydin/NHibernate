using Panel.IService;
using Panel.Models;
using Panel.Repository;
using System.Collections.Generic;

namespace Panel.Service
{
    public class UserService : IUserService
    {
        private readonly RepositoryBase<User> _repository = new RepositoryBase<User>();

        public void UserAdded(User model)
        {
            _repository.Insert(model);
        }

        public IList<User> UserList()
        {
            return _repository.GetList();
        }
    }
}