using AnimalsAppLibrary.Abstractions;
using AnimalsAppLibrary.Data;
using AnimalsAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppLibrary.Repositories
{
    public class BirdRepository : IGenericRepository<Bird>
    {
        private AppDBContext _context;
        public BirdRepository(AppDBContext context)
        {
            _context = context;

        }

        public Bird Add(Bird obj)
        {
            try
            {
                _context.Birds.Add(obj);
                _context.SaveChanges();
                return obj;
            }
            catch (Exception)
            {

                throw new Exception($"Unable to save data on database");
            }

        }

        public void Delete(int id)
        {
            try
            {
                var birds = _context.Birds.FirstOrDefault(n => n.Id == id);
                if (birds != null)
                {
                    _context.Birds.Remove(birds);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"The bird with id: {id} does not exist");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<Bird> GetAll()
        {
            try
            {
                return _context.Birds.ToList();
            }
            catch (Exception)
            {
                throw new Exception($"Unable to get data from database");
            }
        }

        public Bird GetById(int id)
        {
            try
            {
                var bird = _context.Birds.FirstOrDefault(n => n.Id == id);
                if (bird != null)
                {
                    return bird;
                }
                else
                {
                    throw new Exception($"The bird with id: {id} does not exist");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Bird Update(int id, Bird obj)
        {
            var bird = new Bird();
            try
            {
                bird = _context.Birds.FirstOrDefault(x => x.Id == id);
                if (bird != null)
                {
                    bird.Name = obj.Name;
                    bird.breed_Type = obj.breed_Type;
                    bird.Gender = obj.Gender;
                    bird.AgeinYears = obj.AgeinYears;
                    bird.Weight = obj.Weight;
                    bird.Size = obj.Size;
                    bird.Color = obj.Color;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"The cat with id: {id} does not exist");

                }
            }
            catch (Exception)
            {
                throw new Exception($"Unable to update record from database");
            }

            return bird;
        }
    }
}
