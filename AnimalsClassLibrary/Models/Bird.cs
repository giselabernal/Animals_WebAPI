using AnimalsAppLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppLibrary.Models
{
    public class Bird : Animal,  IBird
    {

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public override void MakeNoise()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
