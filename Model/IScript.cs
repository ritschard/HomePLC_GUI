using System;
using System.Collections.Generic;
using System.Text;

namespace HomePLC.Model
{
    public interface IScript
    {
        void Execute(Module mdl);
    }
}
