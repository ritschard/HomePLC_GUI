using System;
using System.Collections.Generic;
using System.Text;

namespace HomePLC.Model
{
    public class HomePLCException : Exception
    {
        public HomePLCException(string reason)
            : base(reason)
        {
        }
    }
}
