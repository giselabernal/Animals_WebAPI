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
    public class DogRepository : IGenericRepository<Dog>
    {
        private AppDBContext _context;
        public DogRepository(AppDBContext context)
        {
            _context = context;

        }

        public Dog Add(Dog obj)
        {
            try
            {
                _context.Dogs.Add(obj);
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
                var dogs = _context.Dogs.FirstOrDefault(n => n.Id == id);
                if (dogs != null)
                {
                    _context.Dogs.Remove(dogs);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"The dog with id: {id} does not exist");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<Dog> GetAll()
        {
            try
            {
                return _context.Dogs.ToList();
            }
            catch (Exception)
            {
                throw new Exception($"Unable to get data from database");
            }
        }

        public Dog GetById(int id)
        {
            try
            {
                var dog = _context.Dogs.FirstOrDefault(n => n.Id == id);
                if (dog != null)
                {
                    return dog;
                }
                else
                {
                    throw new Exception($"The dog with id: {id} does not exist");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Dog Update(int id, Dog obj)
        {
            var dog = new Dog();
            try
            {
                dog = _context.Dogs.FirstOrDefault(x => x.Id == id);
                if (dog != null)
                {
                    dog.Name = obj.Name;
                    dog.breed_Type = obj.breed_Type;
                    dog.Gender = obj.Gender;
                    dog.AgeinYears = obj.AgeinYears;
                    dog.Weight = obj.Weight;
                    dog.Size = obj.Size;
                    dog.Color = obj.Color;
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

            return dog;
        }
    }
}
