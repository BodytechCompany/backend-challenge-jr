using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Common.Exception
{
    public class SegurancaException : System.Exception
    {
        public SegurancaException() : base("Credênciais inválidas.") { }
        public SegurancaException(string message) : base(message) { }
        public SegurancaException(string message, System.Exception inner) : base(message, inner) { }
    }
}