using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer.Exceptions
{
    public class ListNotFoundException : ApplicationException
    {
        public ListNotFoundException() { }
        public ListNotFoundException(string message) : base(message) { }
    }
}
