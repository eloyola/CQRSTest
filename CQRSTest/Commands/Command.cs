using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSTest.Commands
{
    public class Command : EventArgs
    {
        public bool Register = true;
    }
}
