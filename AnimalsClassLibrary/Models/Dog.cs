using AnimalsClassLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsClassLibrary.Models
{
    public class Dog : Mammal,  IMammal
    {

        public void FeedByBreast()
        {
            throw new NotImplementedException();
        }

        public override void MakeNoises()
        {
            throw new NotImplementedException();
        }

        public override void DoMovements()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
