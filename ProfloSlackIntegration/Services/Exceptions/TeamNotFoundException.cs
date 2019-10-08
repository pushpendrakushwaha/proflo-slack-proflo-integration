using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer.Exceptions
{
    public class TeamNotFoundException:ApplicationException
    {
        public TeamNotFoundException() { }
        public TeamNotFoundException(string message) : base(message) { }

    }
}
