using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siiau.Common.Exceptions;

internal class InvalidUrlException : Exception 
{
    public InvalidUrlException(string msg) : base(msg) { }
}
