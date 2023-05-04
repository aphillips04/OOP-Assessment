using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A02_2223
{
    class FailedTestException : Exception
    {
        public FailedTestException()
        {
        }

        public FailedTestException(string message) : base(message)
        {
        }

        public FailedTestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    class EmptyPackException : Exception
    {
        public EmptyPackException()
        {
        }

        public EmptyPackException(string message) : base(message)
        {
        }

        public EmptyPackException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    class InvalidElementCountException : Exception
    {
        public InvalidElementCountException()
        {
        }

        public InvalidElementCountException(string message) : base(message)
        {
        }

        public InvalidElementCountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
