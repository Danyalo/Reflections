using System.Collections.Generic;
using Reflections.Core.Models;

namespace Reflections.Data.Promise
{
    public interface IUserRepository
    {
        User GetById(int id);
        User Update(User updatedUser);
        User Add(User newUser);
        User Delete(int id);
        int Commit();
    }
}
