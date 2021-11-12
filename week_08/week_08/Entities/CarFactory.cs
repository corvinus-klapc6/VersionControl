using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week_08.Abstractions;

namespace week_08.Entities
{
    class CarFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
