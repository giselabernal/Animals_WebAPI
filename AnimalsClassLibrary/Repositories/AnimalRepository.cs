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
    public class AnimalRepository<T> : IGenericRepository<T> where T : Animal
    {
        private AppDBContext _context;

        public AnimalRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(n => n.Id == id);
        }

        public T Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }


        public T Update(int id, T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
