using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer.Exceptions
{
    public class CardAlreadyExistsException :ApplicationException
    {
        public CardAlreadyExistsException() { }
        public CardAlreadyExistsException(string message) : base(message) { }
    }
}
