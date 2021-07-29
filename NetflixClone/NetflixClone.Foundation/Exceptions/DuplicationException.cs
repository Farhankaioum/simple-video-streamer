using System;

namespace NetflixClone.Foundation.Exceptions
{
    public class DuplicationException : Exception
    {
        public DuplicationException(string message)
            : base(message)
        { }
    }
}
