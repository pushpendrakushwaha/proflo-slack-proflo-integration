using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer.Exceptions
{
    public class ListAlreadyExistsException :ApplicationException
    {
        public ListAlreadyExistsException() { }
        public ListAlreadyExistsException(string message) : base(message) { }
    }
}
