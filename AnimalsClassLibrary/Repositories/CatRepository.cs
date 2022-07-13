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
    public class CatRepository : IGenericRepository<Cat>
    {
        private AppDBContext _context;
        public CatRepository(AppDBContext context)
        {
            _context = context;
        
        }

        public Cat Add(Cat obj)
        {
            try
            {
                _context.Cats.Add(obj);
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
                var cats = _context.Cats.FirstOrDefault(n => n.Id == id);
                if (cats != null)
                {
                    _context.Cats.Remove(cats);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"The cat with id: {id} does not exist");
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public IEnumerable<Cat> GetAll()
        {
            try
            {
                return _context.Cats.ToList();
            }
            catch (Exception)
            {
                throw new Exception($"Unable to get data from database");
            }
        }

        public Cat GetById(int id)
        {
            try
            {
                var cat= _context.Cats.FirstOrDefault(n => n.Id == id);
                if (cat!= null)
                {
                    return cat;
                }
                else
                {
                    throw new Exception($"The cat with id: {id} does not exist");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Cat Update(int id, Cat obj)
        {
            var cat = new Cat();
            try
            {
                cat = _context.Cats.FirstOrDefault(x => x.Id == id);
                if (cat != null)
                {
                    cat.Name = obj.Name;
                    cat.breed_Type = obj.breed_Type;
                    cat.Gender = obj.Gender;
                    cat.AgeinYears = obj.AgeinYears;
                    cat.Weight = obj.Weight;
                    cat.Size = obj.Size; 
                    cat.Color = obj.Color;
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
           
            return cat;
        }
    }
}
