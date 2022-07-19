﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsClassLibrary.Abstractions
{
    public interface IAnimal
    {
        void Sleep();
        void EatSomething();
        void DrinkSomething();

        void DoMovements();

        void MakeNoises();
    }
}
