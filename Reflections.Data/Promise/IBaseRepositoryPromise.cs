using System;
namespace Reflections.Data.Promise
{
    public interface IBaseRepositoryPromise<T>
    {
        int Commit();
        T GetById(int id);
        T Update(T updatedEntity);
        T Add(T newEntity);
        T Delete(int id);
    }
}
