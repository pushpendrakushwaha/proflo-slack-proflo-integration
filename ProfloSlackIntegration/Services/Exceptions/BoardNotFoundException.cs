using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloSlackIntegration.BusinessLayer
{
    public class BoardNotFoundException :ApplicationException
    {
        public BoardNotFoundException() { }
        public BoardNotFoundException(string message) : base(message) { }
    }
}
