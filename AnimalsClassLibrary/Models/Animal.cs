using AnimalsAppLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppLibrary.Models
{
    public abstract class Animal : IAnimal
    {
        [Key]
        public int Id { get; set; }
        //public AnymalType AnymalType { get; set; }
        public string Name { get ; set ; }
        public string breed_Type { get; set; }
        public string Gender { get; set; }
        public decimal AgeinYears { get ; set; }
        public decimal Weight { get ; set ; }
        public string Size { get ; set ; }
        public string Color { get ; set ; }
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Sleep()
        {
            throw new NotImplementedException();
        }

        public abstract  void Makenoise();


        public abstract void Move();
       
    }
}
