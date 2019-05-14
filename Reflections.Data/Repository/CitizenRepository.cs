using Microsoft.EntityFrameworkCore;
using Reflections.Core.Models;
using Reflections.Data.Promise;

namespace Reflections.Data.Repository
{
    public class CitizenRepository: BaseRepository<Citizen>, ICitizenRepository
    {
        public CitizenRepository(ReflectionsContext db) 
            : base(db)
        {
        }

        public Citizen Add(Citizen newCitizen)
        {
            db.Citizens.Add(newCitizen);
            return newCitizen;
        }

        public Citizen Delete(int id)
        {
            var citizen = GetById(id);
            if (citizen != null)
            {
                db.Citizens.Remove(citizen);
            }
            return citizen;
        }

        public Citizen GetById(int id)
        {
            return db.Citizens.Find(id);
        }

        public Citizen Update(Citizen updatedCitizen)
        {
            var entity = db.Citizens.Attach(updatedCitizen);
            entity.State = EntityState.Modified;
            return updatedCitizen;
        }
    }
}
