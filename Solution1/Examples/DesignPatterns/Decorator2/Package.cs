using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Decorator2
{
    public abstract class Package : IPackage
    {
        protected IPackage package;
        public Package(IPackage package)
        {
            this.package = package;
        }
        public abstract double RetailPrice
        {
            get;
        }
    }
}
