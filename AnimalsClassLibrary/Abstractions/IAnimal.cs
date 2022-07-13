using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppLibrary.Abstractions
{
    public interface IAnimal
    {
        void Sleep();
        void Makenoise();
        void Move();
        void Eat();
        void Drink();
    }
}
