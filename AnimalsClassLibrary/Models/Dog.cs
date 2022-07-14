using AnimalsAppLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppLibrary.Models
{
    public class Dog : Animal,  IMammal
    {
       // public byte Pelo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       // public string EyeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BreastFeed()
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
