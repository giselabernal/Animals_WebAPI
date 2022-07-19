using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsClassLibrary.Models
{
    public abstract class Mammal: Animal
    {
        public  bool Fur { get; set; }
        public  string EyeColor { get; set; }
        public  bool BreastFeed { get; set; }
    }
}
