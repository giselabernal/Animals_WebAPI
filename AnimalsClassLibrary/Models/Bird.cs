using AnimalsClassLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsClassLibrary.Models
{
    public class Bird : Animal,  IBird
    {
        public bool PutEggs { get; set; }
     
        public void Fly()
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
    }
}
