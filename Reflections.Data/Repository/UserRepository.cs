using Microsoft.EntityFrameworkCore;
using Reflections.Core.Models;
using Reflections.Data.Promise;

namespace Reflections.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ReflectionsContext db)
            : base(db)
        {
        }

        public User Add(User newUser)
        {
            db.Users.Add(newUser);
            return newUser;
        }

        public User Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
            return user;
        }

        public User GetById(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User updatedUser)
        {
            var entity = db.Users.Attach(updatedUser);
            entity.State = EntityState.Modified;
            return updatedUser;
        }
    }
}
