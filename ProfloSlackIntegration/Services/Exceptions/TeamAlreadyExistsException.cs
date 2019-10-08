using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer.Exceptions
{
    public class TeamAlreadyExistsException :ApplicationException
    {
        public TeamAlreadyExistsException() { }
        public TeamAlreadyExistsException(string message) : base(message) { }
    }
}
