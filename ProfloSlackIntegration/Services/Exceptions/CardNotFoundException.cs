using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer.Exceptions
{
    public class CardNotFoundException :ApplicationException
    {
        public CardNotFoundException() { }
        public CardNotFoundException(string message) : base(message) { }
    }
}
