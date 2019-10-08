using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer.Exceptions
{
    public class BoardAlreadyExistsException : ApplicationException
    {
        public BoardAlreadyExistsException() { }
        public BoardAlreadyExistsException(string message) : base(message) { }
    }
}
