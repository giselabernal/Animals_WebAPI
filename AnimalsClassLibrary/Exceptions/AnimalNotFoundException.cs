using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnimalsClassLibrary.Exceptions
{
    [Serializable]
    public class AnimalNotFoundException : Exception
    {
        public string AnimalName { get; set; }    
        public AnimalNotFoundException() { }

        public AnimalNotFoundException(string message)
            : base(message) { }

        public AnimalNotFoundException(string message, Exception inner)
            : base(message, inner) { }

        
    }
}
