using System;
namespace Reflections.Data.Repository
{
    public abstract class BaseRepository<T>
    {
        protected readonly ReflectionsContext db;

        public BaseRepository(ReflectionsContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
