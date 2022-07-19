using AnimalsClassLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsClassLibrary.Models
{
    public abstract class Animal : IAnimal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get ; set ; }
        public string Breed_Type { get; set; }
        public string Gender { get; set; }
        public decimal AgeinYears { get ; set; }
        public decimal Weight { get ; set ; }
        public string Size { get ; set ; }
        public string Color { get ; set ; }

    

        public void DrinkSomething()
        {
            throw new NotImplementedException();
        }

        public void EatSomething()
        {
            throw new NotImplementedException();
        }

        public void Sleep()
        {
            throw new NotImplementedException();
        }

        public abstract  void MakeNoises();


        public abstract void DoMovements();
       
    }
}
