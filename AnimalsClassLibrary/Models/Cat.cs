using AnimalsAppLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppLibrary.Models
{
    public class Cat : Animal,  IMammal

    {
        public void BreastFeed()
        {
            throw new NotImplementedException();
        }

        public override void Makenoise()
        {
            throw new NotImplementedException();
        }

        public override void Move()
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
